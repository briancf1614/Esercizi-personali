using Microsoft.EntityFrameworkCore;
using Regolo2020.Base.DataModels;
using System.Linq.Expressions;
using System.Reflection;

namespace Regolo2020.Base.Business
{
    public class BaseCrudBusiness<TDbContext, TDataModel> : IBusinessCrud<TDbContext, TDataModel>
        where TDbContext : DbContext
        where TDataModel : class, IDataModel
    {
        protected readonly TDbContext _dbContext;

        protected const string NOT_EQUAL = "ne";
        protected const string GREATHER_THEN = "gt";
        protected const string GREATHER_THEN_OR_EQUAL = "gte";
        protected const string LESS_THEN = "lt";
        protected const string LESS_THEN_OR_EQUAL = "lte";
        protected const string LIKE = "like";
        protected const string LIKE_START = "likestart";
        protected const string LIKE_END = "likeend";
        protected const string REGEXP = "regexp";

        protected string[] FilterOperators
        {
            get
            {
                return new string[] { NOT_EQUAL, GREATHER_THEN, GREATHER_THEN_OR_EQUAL, LESS_THEN, LESS_THEN_OR_EQUAL, LIKE, LIKE_START, LIKE_END, REGEXP };
            }
        }

        // ?field=ne:10
        // ?field=10,20,30
        // ?field=gt:10
        // ?field=gte:10
        // ?field=lt:10
        // ?field=lte:10
        // ?field=like:stringvalue
        // ?field=likestart:stringvalue
        // ?field=likeend:stringvalue
        // ?field=regexp:regexpvalue

        public BaseCrudBusiness(TDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// Returns a DbQuery (if the entity is a view) or DbSet (if the entity is a table).
        /// By default tracking is disabled because the context is not exposed outside the repository.
        /// </summary>
        protected IQueryable<TDataModel> GetQuery(bool enableTracking = false)
        {
            IQueryable<TDataModel> query = _dbContext.Set<TDataModel>();
            if (enableTracking == false) query = query.AsNoTracking();

            return query;
        }

        /// <summary>
        /// Returns a modified IQueriable with calls to OrderBy and OrderByDescending according to a dictionary of ordering rules.
        /// </summary>
        //protected IQueryable<T> UpdateQueryWithOrderBy<T>(IQueryable<T> source, SortInfo<T> ordering) where T : class
        //{
        //    Expression queryExpr = source.Expression;
        //    var parameter = Expression.Parameter(source.ElementType, "p");
        //    string methodAsc = "OrderBy";
        //    string methodDesc = "OrderByDescending";

        //    foreach (var o in ordering)
        //    {
        //        Type elementType = source.ElementType;
        //        Expression propertiesExpression = parameter;

        //        foreach (var propertyName in o.Key.Split('.'))
        //        {
        //            PropertyInfo property = elementType.GetProperty(propertyName);
        //            if (property == null) throw new ArgumentException($"Sorter: column name '{o.Key}' not found.");
        //            propertiesExpression = Expression.MakeMemberAccess(propertiesExpression, property);

        //            elementType = property.PropertyType;
        //        }

        //        // Call the LINQ orderBy specific method, passing an expression with the current parameters.
        //        queryExpr = Expression.Call(typeof(Queryable), o.Value ? methodAsc : methodDesc,
        //            new Type[] { source.ElementType, elementType },
        //            queryExpr, Expression.Quote(Expression.Lambda(propertiesExpression, parameter)));
        //        methodAsc = "ThenBy";
        //        methodDesc = "ThenByDescending";
        //    }
        //    return source.Provider.CreateQuery<T>(queryExpr);
        //}

        protected IQueryable<T> UpdateQueryWithPagination<T>(IQueryable<T> dbQuery, int limit, int offset) where T : class, IDataModel
        {
            if (offset > 0) dbQuery = dbQuery.Skip(offset);
            if (limit > 0) dbQuery = dbQuery.Take(limit);

            return dbQuery;
        }

        /// <summary>
        /// Detaches the passed entities from the context. This may be used after an entity has been updated or created,
        /// because the Insert and Update methods will cause the entity to be tracked.
        /// </summary>
        public void Detach(params TDataModel[] entities)
        {
            foreach (var entity in entities) _dbContext.Entry(entity).State = EntityState.Detached;
        }

        /// <summary>
        /// Checks that the context does not have any change that would be pushed to the database when doing a SaveChanges.
        /// This is important to catch possible bugs caused by using a tracking context with repositories.
        /// </summary>
        protected void CheckEmptyContext()
        {
            if (_dbContext.ChangeTracker.HasChanges())
                throw new ArgumentException($"Cannot save changes in repository if the tracker is not empty.");
        }

        public virtual FindResult<TDataModel> Find(string[] fieldsFilter, int limit, int offset)
        {
            IQueryable<TDataModel> dbQuery = GetQuery();

            dbQuery = dbQuery.Where(fieldArrayToWhereExpression(fieldsFilter));

            // Get the count of filtered elements, before applying pagination.
            long count = dbQuery.LongCount();

            // Apply the order by, taken from a dictionary of sorting expressions.
            // if (orderBy != null) dbQuery = UpdateQueryWithOrderBy(dbQuery, orderBy);

            // Apply the pagination filters to the query.
            dbQuery = UpdateQueryWithPagination(dbQuery, limit, offset);

            return new FindResult<TDataModel>(dbQuery.ToList(), count);
        }

        public virtual TDataModel Get(object keyValue, params object[] otherKeyValues)
        {
            var keyValues = new object[] { keyValue }.Concat(otherKeyValues).ToArray();
            var entity = _dbContext.Find<TDataModel>(keyValues);

            // Detach tracked entity, DbSet.Find method cannot be used after IQueryable.AsNoTracking method.
            if (entity != null) Detach(entity);

            return entity;
        }

        public virtual long Count(Expression<Func<TDataModel, bool>> where)
        {
            IQueryable<TDataModel> dbQuery = GetQuery();
            dbQuery = dbQuery.Where(where);

            return dbQuery.LongCount();
        }

        public virtual TDataModel Insert(TDataModel item)
        {
            CheckEmptyContext();

            // Inserts the new item and any related entity that is referenced from it.
            var entry = _dbContext.Add(item);
            _dbContext.SaveChanges();
            Detach(item);

            return entry.Entity;
        }

        public virtual void Update(params TDataModel[] items)
        {
            CheckEmptyContext();

            // Updates all the given entities. If the items have related entities those will be updated too.
            _dbContext.UpdateRange(items);
            _dbContext.SaveChanges();
            Detach(items);
        }

        public virtual int Delete(params TDataModel[] items)
        {
            CheckEmptyContext();

            // Removes all the given entities. If the items have required relationships, the child/dependent entities will be deleted too.
            // If the items have optional relationships (nullable fk) the child/dependent entities will not be deleted, but the FK will be set to NULL.
            _dbContext.RemoveRange(items);
            int result = _dbContext.SaveChanges();
            Detach(items);

            return result;
        }

        private bool IsNullableType(Type t)
        {
            return t.IsGenericType && t.GetGenericTypeDefinition() == typeof(Nullable<>);
        }

        private Expression<Func<TDataModel, bool>> fieldArrayToWhereExpression(string[] fieldsFilter)
        {
            var modelType = typeof(TDataModel);
            var parameter = Expression.Parameter(modelType);

            Expression? combined = null;

            // Loop over all fields to filter.
            foreach (var field in fieldsFilter)
            {
                string propName = field.Split('=')[0];

                // Get the corresponding property in the model (db entity), if present.
                PropertyInfo? modelProp = modelType.GetProperty(propName, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
                if (modelProp == null) throw new ArgumentException($"Property '{propName}' not found on entity {modelType.FullName}");

                string filterApiValue = field.Split('=')[1];
                string? filterMode = FilterOperators.OrderByDescending(fo => fo.Length).FirstOrDefault(o => filterApiValue.StartsWith(o));

                object filterValue = Convert.ChangeType(filterMode == null ? filterApiValue : filterApiValue.Split(":")[1], modelProp.PropertyType);

                // Creates an expression representing the array of values on which "Contains" will be called.
                // This is needed because using directly an Expression.Constant of the filter value would create
                // a resulting expression that EF Core sees as always different from the previous expressions.
                // This in tur would cause EF Core to cache a new query plan each time, leaking memory in the cache.
                // The fix is to create an anonymous object (which can be constant) and access one of its properties
                // "Prop" which may not be constant (even if the parent is constant).
                // https://stackoverflow.com/questions/54075758
                var expGetFilterValue = Expression.Convert(Expression.Property(
                    Expression.Constant(new { Prop = filterValue }), "Prop"), modelProp.PropertyType);

                var expGetModelValue = Expression.Property(parameter, modelProp.Name);

                Expression curExpression;

                if (filterMode == NOT_EQUAL)
                {
                    curExpression = Expression.NotEqual(expGetModelValue, expGetFilterValue);
                }
                else if (filterMode == GREATHER_THEN)
                {
                    curExpression = Expression.GreaterThan(expGetModelValue, expGetFilterValue);
                }
                else if (filterMode == GREATHER_THEN_OR_EQUAL)
                {
                    curExpression = Expression.GreaterThanOrEqual(expGetModelValue, expGetFilterValue);
                }
                else if (filterMode == LESS_THEN)
                {
                    curExpression = Expression.LessThan(expGetModelValue, expGetFilterValue);
                }
                else if (filterMode == LESS_THEN_OR_EQUAL)
                {
                    curExpression = Expression.LessThanOrEqual(expGetModelValue, expGetFilterValue);
                }
                else if (filterMode == LIKE)
                {
                    // TODO
                    curExpression = Expression.Equal(expGetModelValue, expGetFilterValue);
                }
                else
                {
                    curExpression = Expression.Equal(expGetModelValue, expGetFilterValue);
                }


                // Concatenate all the filter conditions with logical AND ('And' is different from 'AndAlso').
                combined = combined == null ? curExpression : Expression.AndAlso(combined, curExpression);
            }

            // If the filter did not apply any expression, return an always true expression.
            if (combined == null) combined = Expression.Constant(true);

            return Expression.Lambda<Func<TDataModel, bool>>(combined, parameter);
        }
    }
}

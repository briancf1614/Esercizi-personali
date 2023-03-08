using Microsoft.EntityFrameworkCore;

namespace Regolo2020.Base.DataModels
{
    public class RegoloDbContext : DbContext
    {
        public RegoloDbContext(DbContextOptions<RegoloDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            CreateModelFromTableAssemblyTypes(modelBuilder);
        }

        public static void CreateModelFromTableAssemblyTypes(ModelBuilder modelBuilder, string nameSpaceFilter = "")
        {
            var tableAssemblyType = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(tat => tat.GetTypes())
                .Where(tat => !tat.IsInterface && !tat.IsAbstract && typeof(IDataModel).IsAssignableFrom(tat));

            if (!string.IsNullOrEmpty(nameSpaceFilter))
            {
                tableAssemblyType = tableAssemblyType.Where(tat => tat.Namespace == nameSpaceFilter);
            }

            foreach (var tat in tableAssemblyType)
            {
                string tableName = tat.Name[..7] + "_" + tat.Name[7..];
                modelBuilder.Entity(tat).ToTable(tableName.ToLower());
            }
        }
    }
}

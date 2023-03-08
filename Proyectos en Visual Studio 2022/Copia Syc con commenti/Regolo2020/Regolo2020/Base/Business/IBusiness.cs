using Microsoft.EntityFrameworkCore;
using Regolo2020.Base.DataModels;

namespace Regolo2020.Base.Business
{
    public interface IBusiness
    {
    }

    public interface IBusinessCrud<TDbContext, TDataModel> : IBusiness
        where TDbContext : DbContext
        where TDataModel : class, IDataModel
    {
        FindResult<TDataModel> Find(string[] fieldsFilter, int limit, int offset);
        TDataModel Get(object key, params object[] otherKeys);
        TDataModel Insert(TDataModel item);
        void Update(params TDataModel[] items);
        int Delete(params TDataModel[] items);
    }
}

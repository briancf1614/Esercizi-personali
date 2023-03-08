using Regolo2020.Base.DataModels;

namespace Regolo2020.Base.Business
{
    public class FindResult<TDataModel> where TDataModel : class, IDataModel
    {
        public IList<TDataModel> Data { get; set; }
        public long Count { get; set; }

        public FindResult(IList<TDataModel> data, long count)
        {
            Data = data;
            Count = count;
        }
    }
}

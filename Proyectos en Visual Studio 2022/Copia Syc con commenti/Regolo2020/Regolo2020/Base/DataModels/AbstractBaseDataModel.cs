using System.ComponentModel.DataAnnotations;

namespace Regolo2020.Base.DataModels
{
    public abstract class AbstractBaseDataModel : IDataModel
    {
        [Key]
        public int Id { get; set; }
    }
}

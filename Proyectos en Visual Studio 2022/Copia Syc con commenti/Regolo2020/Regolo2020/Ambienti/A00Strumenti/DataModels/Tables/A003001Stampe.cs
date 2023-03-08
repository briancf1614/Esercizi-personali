using Regolo2020.Base.DataModels;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Regolo2020.Ambienti.A00Strumenti.DataModels.Tables
{
    [Index(nameof(CodiceStampa), IsUnique = true)]
    public class A003001Stampe : AbstractBaseDataModel
    {
        [MaxLength(20)]
        public string CodiceStampa { get; set; }

        [MaxLength(256)]
        public string PathNameTemplate { get; set; }

        [MaxLength(40)]
        public string Namespace { get; set; }

        [MaxLength(40)]
        public string ClassNameFormatData { get; set; }

        [MaxLength(40)]
        public string ClassNameData { get; set; }
    }
}

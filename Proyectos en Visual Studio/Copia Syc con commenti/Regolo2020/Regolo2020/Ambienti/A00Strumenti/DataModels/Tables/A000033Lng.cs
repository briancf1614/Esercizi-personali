using Regolo2020.Base.DataModels;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Regolo2020.Ambienti.A00Strumenti.DataModels.Tables
{
    public class A000033Lng : AbstractBaseDataModel
    {
        [MaxLength(4)]
        public string LngCod { get; set; }

        [MaxLength(100)]
        public string Ambiente { get; set; }

        [MaxLength(100)]
        public string FieldName { get; set; }

        public string LngDesc { get; set; }
    }
}

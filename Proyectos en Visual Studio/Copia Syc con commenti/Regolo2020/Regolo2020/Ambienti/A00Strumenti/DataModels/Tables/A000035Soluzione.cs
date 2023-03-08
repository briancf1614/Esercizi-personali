using Regolo2020.Base.DataModels;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Regolo2020.Ambienti.A00Strumenti.DataModels.Tables
{
    [Index(nameof(IdentificativoUnivocoUtilizzatore), IsUnique = true)]
    public class A000035Soluzione : AbstractBaseDataModel
    {
        [MaxLength(256)]
        public string Token { get; set; }

        [MaxLength(100)]
        public string Descrizione { get; set; }

        public DateTime DataFineValidita { get; set; }

        [MaxLength(50)]
        public string IdentificativoUnivocoUtilizzatore { get; set; }

        [MaxLength(10)]
        public string TipoToken { get; set; }
    }
}

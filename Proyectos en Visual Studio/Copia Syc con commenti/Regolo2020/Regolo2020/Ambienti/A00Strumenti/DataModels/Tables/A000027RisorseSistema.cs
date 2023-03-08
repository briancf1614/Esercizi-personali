using Regolo2020.Base.DataModels;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Regolo2020.Ambienti.A00Strumenti.DataModels.Tables
{
    public class A000027RisorseSistema : AbstractBaseDataModel
    {
        [MaxLength(50)]
        public string NomeRisorsa { get; set; }

        [MaxLength(100)]
        public string Descrizione { get; set; }

        [InverseProperty(nameof(A000028PermessiRisorse.NomeRisorsa))]
        public ICollection<A000028PermessiRisorse> PermessiRisorse { get; set; }
    }
}

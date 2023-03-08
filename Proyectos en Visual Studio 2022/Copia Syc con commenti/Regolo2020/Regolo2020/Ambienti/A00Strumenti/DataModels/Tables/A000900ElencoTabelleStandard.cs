using Regolo2020.Base.DataModels;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Regolo2020.Ambienti.A00Strumenti.DataModels.Tables
{
    [Index(nameof(CodiceTabella), IsUnique = true)]
    public class A000900ElencoTabelleStandard : AbstractBaseDataModel
    {
        public int IdCodiceAmbiente { get; set; }

        [MaxLength(7)]
        public string CodiceTabella { get; set; }

        [MaxLength(100)]
        public string Descrizione { get; set; }

        [MaxLength(5)]
        public string Sigla { get; set; }

        [ForeignKey(nameof(IdCodiceAmbiente))]
        public A000001AmbientiApplicativi CodiceAmbiente { get; set; }

        [InverseProperty(nameof(A000902TabelleStandard.CodiceTabella))]
        public ICollection<A000902TabelleStandard> TabelleStandard { get; set; }
    }
}

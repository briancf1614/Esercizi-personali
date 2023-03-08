using Regolo2020.Base.DataModels;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Regolo2020.Ambienti.A00Strumenti.DataModels.Tables
{
    [Index(nameof(CodiceAmbiente), IsUnique = true)]
    public class A000001AmbientiApplicativi : AbstractBaseDataModel
    {
        [MaxLength(3)]
        public string CodiceAmbiente { get; set; }

        [MaxLength(100)]
        public string Ambiente { get; set; }

        [MaxLength(100)]
        public string Descrizione { get; set; }

        [MaxLength(100)]
        public string UrlStart { get; set; }

        public int Versione { get; set; }

        [InverseProperty(nameof(A000002Entita.Ambiente))]
        public ICollection<A000002Entita> Entita { get; set; }

        [InverseProperty(nameof(A000003Campi.Ambiente))]
        public ICollection<A000003Campi> Campi { get; set; }

        [InverseProperty(nameof(A000005Applicazioni.AmbienteApplicativo))]
        public ICollection<A000005Applicazioni> Applicazioni { get; set; }

        [InverseProperty(nameof(A000017LayoutAmbienti.Ambiente))]
        public ICollection<A000017LayoutAmbienti> LayoutAmbienti { get; set; }

        [InverseProperty(nameof(A000900ElencoTabelleStandard.CodiceAmbiente))]
        public ICollection<A000900ElencoTabelleStandard> ElencoTabelleStandard { get; set; }
    }
}

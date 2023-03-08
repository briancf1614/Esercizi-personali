using Regolo2020.Base.DataModels;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Regolo2020.Ambienti.A00Strumenti.DataModels.Tables
{
    public class A000017LayoutAmbienti : AbstractBaseDataModel
    {
        public int IdAmbiente { get; set; }

        public int Ordine { get; set; }

        [MaxLength(20)]
        public string Icon { get; set; }

        [MaxLength(100)]
        public string Testo { get; set; }

        [MaxLength(40)]
        public string Color { get; set; }

        [MaxLength(40)]
        public string ColorHover { get; set; }

        [MaxLength(40)]
        public string BgColor { get; set; }

        [MaxLength(100)]
        public string Descrizione { get; set; }

        [ForeignKey(nameof(IdAmbiente))]
        public A000001AmbientiApplicativi Ambiente { get; set; }

        [InverseProperty(nameof(A000018LayoutPage.LayoutAmbiente))]
        public ICollection<A000018LayoutPage> LayoutPage { get; set; }
    }
}

using Regolo2020.Base.DataModels;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Regolo2020.Ambienti.A00Strumenti.DataModels.Tables
{
    public class A000022LayoutListeValori : AbstractBaseDataModel
    {
        public int IdLayoutDetail { get; set; }

        public int IdLayoutPage { get; set; }

        public int IdLayoutSubDetail { get; set; }

        [MaxLength(40)]
        public string Valore { get; set; }

        [MaxLength(40)]
        public string Descrizione { get; set; }

        [ForeignKey(nameof(IdLayoutDetail))]
        public A000020LayoutDetail LayoutDetail { get; set; }

        [ForeignKey(nameof(IdLayoutPage))]
        public A000018LayoutPage LayoutPage { get; set; }
    }
}

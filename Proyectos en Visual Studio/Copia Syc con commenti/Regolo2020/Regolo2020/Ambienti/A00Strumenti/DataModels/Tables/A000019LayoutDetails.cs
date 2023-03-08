using Regolo2020.Base.DataModels;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Regolo2020.Ambienti.A00Strumenti.DataModels.Tables
{
    public class A000019LayoutDetails : AbstractBaseDataModel
    {
        public int IdLayoutPage { get; set; }

        [MaxLength(40)]
        public string NomeCampo { get; set; }

        [MaxLength(40)]
        public string Label { get; set; }

        [MaxLength(20)]
        public string Type { get; set; }

        public bool Visible { get; set; }

        public bool Copy { get; set; }

        public bool Paste { get; set; }

        [ForeignKey(nameof(IdLayoutPage))]
        public A000018LayoutPage LayoutPage { get; set; }
    }
}

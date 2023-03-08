using Regolo2020.Base.DataModels;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Regolo2020.Ambienti.A00Strumenti.DataModels.Tables
{
    public class A000025LayoutTreeView : AbstractBaseDataModel
    {
        public int IdLayoutPage { get; set; }

        public int IdLayoutDetail { get; set; }

        [MaxLength(40)]
        public string NomeCampo { get; set; }

        public int ColSize { get; set; }

        [MaxLength(40)]
        public string Label { get; set; }

        [MaxLength(20)]
        public string Type { get; set; }

        [MaxLength(20)]
        public string Icon { get; set; }

        public bool ReadOnly { get; set; }

        public bool Required { get; set; }

        [MaxLength(20)]
        public string GroupCode { get; set; }

        [MaxLength(40)]
        public string ChildItem { get; set; }

        public bool Ins { get; set; }

        public bool Del { get; set; }

        public bool Search { get; set; }

        [MaxLength(40)]
        public string TabName { get; set; }

        [ForeignKey(nameof(IdLayoutPage))]
        public A000018LayoutPage LayoutPage { get; set; }

        [ForeignKey(nameof(IdLayoutDetail))]
        public A000020LayoutDetail LayoutDetail { get; set; }
    }
}

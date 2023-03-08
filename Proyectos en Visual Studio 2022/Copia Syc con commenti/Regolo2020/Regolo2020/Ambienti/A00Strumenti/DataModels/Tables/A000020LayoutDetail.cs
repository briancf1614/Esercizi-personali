using Regolo2020.Base.DataModels;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Regolo2020.Ambienti.A00Strumenti.DataModels.Tables
{
    public class A000020LayoutDetail : AbstractBaseDataModel
    {
        public int IdLayoutPage { get; set; }

        [MaxLength(40)]
        public string NomeCampo { get; set; }

        public int ColSize { get; set; }

        [MaxLength(40)]
        public string Label { get; set; }

        [MaxLength(20)]
        public string Type { get; set; }

        [MaxLength(20)]
        public string TypeAction { get; set; }

        [MaxLength(30)]
        public string Icon { get; set; }

        public bool ReadOnly { get; set; }

        public bool Required { get; set; }

        [MaxLength(100)]
        public string PreSave { get; set; }

        [MaxLength(200)]
        public string PreSaveParams { get; set; }

        [MaxLength(100)]
        public string PreLoad { get; set; }

        [MaxLength(200)]
        public string PreLoadParams { get; set; }

        [MaxLength(100)]
        public string OnChange { get; set; }

        [MaxLength(200)]
        public string OnChangeParams { get; set; }

        [MaxLength(20)]
        public string GroupCode { get; set; }

        [MaxLength(200)]
        public string Validazione { get; set; }

        public int Min { get; set; }

        public int Max { get; set; }

        public int Step { get; set; }

        [MaxLength(10)]
        public string Orientation { get; set; }

        [MaxLength(10)]
        public string Localization { get; set; }

        [MaxLength(10)]
        public string Currency { get; set; }

        public bool MultiSelect { get; set; }

        public bool ShowDecimal { get; set; }

        public bool LayoutForNew { get; set; }

        public bool Copy { get; set; }

        public bool Paste { get; set; }

        [ForeignKey(nameof(IdLayoutPage))]
        public A000018LayoutPage LayoutPage { get; set; }

        [InverseProperty(nameof(A000022LayoutListeValori.LayoutDetail))]
        public ICollection<A000022LayoutListeValori> LayoutListeValori { get; set; }

        [InverseProperty(nameof(A000024LayoutDataGrid.LayoutDetail))]
        public ICollection<A000024LayoutDataGrid> LayoutDataGrid { get; set; }

        [InverseProperty(nameof(A000025LayoutTreeView.LayoutDetail))]
        public ICollection<A000025LayoutTreeView> LayoutTreeView { get; set; }

        [InverseProperty(nameof(A000029LayoutListView.LayoutDetail))]
        public ICollection<A000029LayoutListView> LayoutListView { get; set; }
    }
}

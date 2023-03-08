using Regolo2020.Base.DataModels;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Regolo2020.Ambienti.A00Strumenti.DataModels.Tables
{
    public class A000018LayoutPage : AbstractBaseDataModel
    {
        public int IdLayoutAmbiente { get; set; }

        [MaxLength(50)]
        public string LabelSingolare { get; set; }

        [MaxLength(50)]
        public string LabelPlurale { get; set; }

        [MaxLength(40)]
        public string LabelTab { get; set; }

        [MaxLength(40)]
        public string TabName { get; set; }

        public int Ordine { get; set; }

        [MaxLength(80)]
        public string Title { get; set; }

        public bool Ins { get; set; }

        public bool Upd { get; set; }

        public bool Del { get; set; }

        [MaxLength(80)]
        public string DetailsTitle { get; set; }

        public int DetailsMaxRows { get; set; }

        public int DetailsMaxPageRows { get; set; }

        [MaxLength(80)]
        public string DetailTitle { get; set; }

        [MaxLength(100)]
        public string UrlTab { get; set; }

        [MaxLength(100)]
        public string PreSave { get; set; }

        public bool Reload { get; set; }

        [MaxLength(40)]
        public string TypeMode { get; set; }

        public bool Private { get; set; }

        public bool Filter { get; set; }

        [MaxLength(40)]
        public string ViewMode { get; set; }

        [ForeignKey(nameof(IdLayoutAmbiente))]
        public A000017LayoutAmbienti LayoutAmbiente { get; set; }

        [InverseProperty(nameof(A000019LayoutDetails.LayoutPage))]
        public ICollection<A000019LayoutDetails> LayoutDetails { get; set; }

        [InverseProperty(nameof(A000020LayoutDetail.LayoutPage))]
        public ICollection<A000020LayoutDetail> LayoutDetail { get; set; }

        [InverseProperty(nameof(A000021LayoutGroups.LayoutPage))]
        public ICollection<A000021LayoutGroups> LayoutGroups { get; set; }

        [InverseProperty(nameof(A000024LayoutDataGrid.LayoutPage))]
        public ICollection<A000024LayoutDataGrid> LayoutDataGrid { get; set; }

        [InverseProperty(nameof(A000025LayoutTreeView.LayoutPage))]
        public ICollection<A000025LayoutTreeView> LayoutTreeView { get; set; }

        [InverseProperty(nameof(A000029LayoutListView.LayoutPage))]
        public ICollection<A000029LayoutListView> LayoutListView { get; set; }

        [InverseProperty(nameof(A000031LayoutBlockView.LayoutPage))]
        public ICollection<A000031LayoutBlockView> LayoutBlockView { get; set; }
    }
}

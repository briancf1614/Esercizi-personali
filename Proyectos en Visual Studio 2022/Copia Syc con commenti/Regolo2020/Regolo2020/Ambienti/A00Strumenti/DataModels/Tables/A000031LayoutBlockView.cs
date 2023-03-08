using Regolo2020.Base.DataModels;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Regolo2020.Ambienti.A00Strumenti.DataModels.Tables
{
    public class A000031LayoutBlockView : AbstractBaseDataModel
    {
        public int IdLayoutPage { get; set; }

        public int IdLayoutParent { get; set; }

        [MaxLength(40)]
        public string NomeCampo { get; set; }

        public int ColSize { get; set; }

        [MaxLength(40)]
        public string Label { get; set; }

        [MaxLength(20)]
        public string Type { get; set; }

        [MaxLength(20)]
        public string Icon { get; set; }

        [MaxLength(10)]
        public string Color { get; set; }

        [MaxLength(20)]
        public string Orientation { get; set; }

        public bool ReadOnly { get; set; }

        public bool Required { get; set; }

        [MaxLength(20)]
        public string GroupCode { get; set; }

        [MaxLength(100)]
        public string OnChange { get; set; }

        [MaxLength(200)]
        public string OnChangeParams { get; set; }

        [MaxLength(100)]
        public string PreLoad { get; set; }

        [MaxLength(200)]
        public string PreLoadParams { get; set; }

        [ForeignKey(nameof(IdLayoutPage))]
        public A000018LayoutPage LayoutPage { get; set; }
    }
}

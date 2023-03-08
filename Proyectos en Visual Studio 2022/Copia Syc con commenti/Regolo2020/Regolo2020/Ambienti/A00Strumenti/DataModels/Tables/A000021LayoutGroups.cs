using Regolo2020.Base.DataModels;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Regolo2020.Ambienti.A00Strumenti.DataModels.Tables
{
    [Index(nameof(Label), IsUnique = true)]
    public class A000021LayoutGroups : AbstractBaseDataModel
    {
        public int IdLayoutPage { get; set; }

        [MaxLength(20)]
        public string GroupCode { get; set; }

        [MaxLength(25)]
        public string Label { get; set; }

        [ForeignKey(nameof(IdLayoutPage))]
        public A000018LayoutPage LayoutPage { get; set; }
    }
}

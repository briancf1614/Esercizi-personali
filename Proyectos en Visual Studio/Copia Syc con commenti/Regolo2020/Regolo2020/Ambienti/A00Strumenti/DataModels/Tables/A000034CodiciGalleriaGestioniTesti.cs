using Regolo2020.Base.DataModels;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Regolo2020.Ambienti.A00Strumenti.DataModels.Tables
{
    [Index(nameof(CodiceRifApp), IsUnique = true)]
    public class A000034CodiciGalleriaGestioniTesti : AbstractBaseDataModel
    {
        [MaxLength(7)]
        public string CodiceGalleria { get; set; }

        public int IdTipoGalleriaTesti { get; set; }

        [MaxLength(50)]
        public string CodiceRifApp { get; set; }

        [MaxLength(100)]
        public string Descrizione { get; set; }

        [ForeignKey(nameof(IdTipoGalleriaTesti))]
        public A000902TabelleStandard TipoGalleriaTesti { get; set; }

        [InverseProperty(nameof(A000036TestiGallerie.Galleria))]
        public ICollection<A000036TestiGallerie> TestiGallerie { get; set; }
    }
}

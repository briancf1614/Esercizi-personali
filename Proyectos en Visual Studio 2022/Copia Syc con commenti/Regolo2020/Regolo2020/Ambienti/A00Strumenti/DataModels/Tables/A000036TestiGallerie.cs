using Regolo2020.Base.DataModels;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Regolo2020.Ambienti.A00Strumenti.DataModels.Tables
{
    public class A000036TestiGallerie : AbstractBaseDataModel
    {
        public int IdGalleria { get; set; }

        public int NumeroParagrafo { get; set; }

        public string Testo { get; set; }

        public DateTime DataValidita { get; set; }

        public DateTime DataCessazione { get; set; }

        [ForeignKey(nameof(IdGalleria))]
        public A000034CodiciGalleriaGestioniTesti Galleria { get; set; }
    }
}

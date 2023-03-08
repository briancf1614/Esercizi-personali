using Regolo2020.Base.DataModels;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Regolo2020.Ambienti.A00Strumenti.DataModels.Tables
{
    public class A000902TabelleStandard : AbstractBaseDataModel
    {
        public int IdCodiceTabella { get; set; }

        [MaxLength(6)]
        public string CodiceTipologia { get; set; }

        [MaxLength(100)]
        public string Descrizione { get; set; }

        [ForeignKey(nameof(IdCodiceTabella))]
        public A000900ElencoTabelleStandard CodiceTabella { get; set; }

        [InverseProperty(nameof(A000034CodiciGalleriaGestioniTesti.TipoGalleriaTesti))]
        public ICollection<A000034CodiciGalleriaGestioniTesti> CodiciGalleriaGestioniTesti { get; set; }
    }
}

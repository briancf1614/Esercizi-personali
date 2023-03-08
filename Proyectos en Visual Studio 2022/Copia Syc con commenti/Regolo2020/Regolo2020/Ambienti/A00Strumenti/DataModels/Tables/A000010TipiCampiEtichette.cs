using Regolo2020.Base.DataModels;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Regolo2020.Ambienti.A00Strumenti.DataModels.Tables
{
    [Index(nameof(CodiceCampo), IsUnique = true)]
    public class A000010TipiCampiEtichette : AbstractBaseDataModel
    {
        [MaxLength(7)]
        public string CodiceCampo { get; set; }

        [MaxLength(50)]
        public string Descrizione { get; set; }

        [MaxLength(1)]
        public string MissingFill { get; set; }

        [InverseProperty(nameof(A000009CampiEtichettaNumerazione.TipoCampo))]
        public ICollection<A000009CampiEtichettaNumerazione> CampiEtichettaNumerazione { get; set; }
    }
}

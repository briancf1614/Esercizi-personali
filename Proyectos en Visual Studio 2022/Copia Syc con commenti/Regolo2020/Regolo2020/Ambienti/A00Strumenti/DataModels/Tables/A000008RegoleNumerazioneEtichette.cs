using Regolo2020.Base.DataModels;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Regolo2020.Ambienti.A00Strumenti.DataModels.Tables
{
    [Index(nameof(CodiceRegola), IsUnique = true)]
    public class A000008RegoleNumerazioneEtichette : AbstractBaseDataModel
    {
        [MaxLength(50)]
        public string CodiceRegola { get; set; }

        public int IdCampoDaEtichettare { get; set; }

        [ForeignKey(nameof(IdCampoDaEtichettare))]
        public A000003Campi CampoDaEtichettare { get; set; }

        [InverseProperty(nameof(A000009CampiEtichettaNumerazione.Regola))]
        public ICollection<A000009CampiEtichettaNumerazione> CampiEtichettaNumerazione { get; set; }

        [InverseProperty(nameof(A000011NumerazioneAutomatica.Regola))]
        public ICollection<A000011NumerazioneAutomatica> NumerazioneAutomatica { get; set; }
    }
}

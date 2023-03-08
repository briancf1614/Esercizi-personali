using Regolo2020.Base.DataModels;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Regolo2020.Ambienti.A00Strumenti.DataModels.Tables
{
    public class A000003Campi : AbstractBaseDataModel
    {
        public int IdCodiceEntita { get; set; }

        [MaxLength(50)]
        public string NomeCampoEntita { get; set; }

        public int IdRegola { get; set; }

        public int IdAmbiente { get; set; }

        [ForeignKey(nameof(IdCodiceEntita))]
        public A000002Entita CodiceEntita { get; set; }

        [ForeignKey(nameof(IdAmbiente))]
        public A000001AmbientiApplicativi Ambiente { get; set; }

        [InverseProperty(nameof(A000008RegoleNumerazioneEtichette.CampoDaEtichettare))]
        public ICollection<A000008RegoleNumerazioneEtichette> RegoleNumerazioneEtichette { get; set; }
    }
}

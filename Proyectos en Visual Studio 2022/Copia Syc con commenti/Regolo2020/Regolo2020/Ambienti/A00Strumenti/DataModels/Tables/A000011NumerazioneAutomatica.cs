using Regolo2020.Base.DataModels;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Regolo2020.Ambienti.A00Strumenti.DataModels.Tables
{
    public class A000011NumerazioneAutomatica : AbstractBaseDataModel
    {
        public int IdRegola { get; set; }

        [MaxLength(50)]
        public string CampiChiaveNumerazione { get; set; }

        public int Numerazione { get; set; }

        [ForeignKey(nameof(IdRegola))]
        public A000008RegoleNumerazioneEtichette Regola { get; set; }
    }
}

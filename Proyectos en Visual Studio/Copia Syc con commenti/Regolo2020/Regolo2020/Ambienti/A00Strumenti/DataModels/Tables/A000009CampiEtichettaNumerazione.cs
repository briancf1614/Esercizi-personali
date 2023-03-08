using Regolo2020.Base.DataModels;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Regolo2020.Ambienti.A00Strumenti.DataModels.Tables
{
    public class A000009CampiEtichettaNumerazione : AbstractBaseDataModel
    {
        public int IdRegola { get; set; }

        public int IdTipoCampo { get; set; }

        [MaxLength(30)]
        public string NomeCampo { get; set; }

        [MaxLength(50)]
        public string ContenutoCampo { get; set; }

        public int Sequenza { get; set; }

        public bool DaEsporre { get; set; }

        public int LLcampoEtichetta { get; set; }

        [MaxLength(1)]
        public string Riempimento { get; set; }

        [MaxLength(1)]
        public string Allineamento { get; set; }

        public bool DaCalcolare { get; set; }

        [ForeignKey(nameof(IdRegola))]
        public A000008RegoleNumerazioneEtichette Regola { get; set; }

        [ForeignKey(nameof(IdTipoCampo))]
        public A000010TipiCampiEtichette TipoCampo { get; set; }
    }
}

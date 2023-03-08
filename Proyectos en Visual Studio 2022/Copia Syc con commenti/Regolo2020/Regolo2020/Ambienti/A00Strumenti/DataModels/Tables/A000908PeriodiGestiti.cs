using Regolo2020.Base.DataModels;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Regolo2020.Ambienti.A00Strumenti.DataModels.Tables
{
    public class A000908PeriodiGestiti : AbstractBaseDataModel
    {
        [MaxLength(6)]
        public string TipoPeriodo { get; set; }

        [MaxLength(100)]
        public string Descrizione { get; set; }

        public int NumeroMinutiPeriodo { get; set; }
    }
}

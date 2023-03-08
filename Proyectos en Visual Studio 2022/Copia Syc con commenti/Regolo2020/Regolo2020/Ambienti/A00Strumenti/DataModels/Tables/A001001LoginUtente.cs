using Regolo2020.Base.DataModels;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Regolo2020.Ambienti.A00Strumenti.DataModels.Tables
{
    public class A001001LoginUtente : AbstractBaseDataModel
    {
        [MaxLength(130)]
        public string User { get; set; }

        [MaxLength(130)]
        public string Password { get; set; }

        [MaxLength(130)]
        public string Salt { get; set; }

        [MaxLength(200)]
        public string Descrizione { get; set; }

        public int PrimarySetting { get; set; }

        public int IdRapporto { get; set; }

        public DateTime DataFineValidita { get; set; }

        public int NumFailedLogin { get; set; }

        public bool ForceChangePwd { get; set; }

        public bool Connected { get; set; }

        public DateTime LastCheck { get; set; }

        [InverseProperty(nameof(A000028PermessiRisorse.Login))]
        public ICollection<A000028PermessiRisorse> PermessiRisorse { get; set; }
    }
}

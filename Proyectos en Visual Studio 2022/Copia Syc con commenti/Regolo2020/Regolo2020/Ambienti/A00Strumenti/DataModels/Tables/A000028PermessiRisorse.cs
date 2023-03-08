using Regolo2020.Base.DataModels;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Regolo2020.Ambienti.A00Strumenti.DataModels.Tables
{
    public class A000028PermessiRisorse : AbstractBaseDataModel
    {
        public int IdLogin { get; set; }

        public int IdNomeRisorsa { get; set; }

        public int Setting { get; set; }

        [ForeignKey(nameof(IdLogin))]
        public A001001LoginUtente Login { get; set; }

        [ForeignKey(nameof(IdNomeRisorsa))]
        public A000027RisorseSistema NomeRisorsa { get; set; }
    }
}

using Regolo2020.Base.DataModels;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Regolo2020.Ambienti.A00Strumenti.DataModels.Tables
{
    public class A000015EntitaGuidaApplicativa : AbstractBaseDataModel
    {
        public int IdGuidaApplicativa { get; set; }

        public int IdEntita { get; set; }

        public int IdGuidaAIdServiziopplicativa { get; set; }

        [ForeignKey(nameof(IdGuidaApplicativa))]
        public A000014GuidaApplicativa GuidaApplicativa { get; set; }

        [ForeignKey(nameof(IdEntita))]
        public A000002Entita Entita { get; set; }

        [ForeignKey(nameof(IdGuidaAIdServiziopplicativa))]
        public A000004Servizi GuidaAIdServiziopplicativa { get; set; }
    }
}

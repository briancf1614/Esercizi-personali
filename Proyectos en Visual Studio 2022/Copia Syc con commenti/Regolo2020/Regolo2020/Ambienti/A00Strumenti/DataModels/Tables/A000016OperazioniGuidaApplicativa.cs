using Regolo2020.Base.DataModels;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Regolo2020.Ambienti.A00Strumenti.DataModels.Tables
{
    public class A000016OperazioniGuidaApplicativa : AbstractBaseDataModel
    {
        public int IdGuidaApplicativa { get; set; }

        public int IdOperazione { get; set; }

        [ForeignKey(nameof(IdGuidaApplicativa))]
        public A000014GuidaApplicativa GuidaApplicativa { get; set; }

        [ForeignKey(nameof(IdOperazione))]
        public A000007Operazioni Operazione { get; set; }
    }
}

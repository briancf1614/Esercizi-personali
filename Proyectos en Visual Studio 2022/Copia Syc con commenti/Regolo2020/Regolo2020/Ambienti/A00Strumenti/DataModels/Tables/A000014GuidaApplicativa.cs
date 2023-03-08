using Regolo2020.Base.DataModels;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Regolo2020.Ambienti.A00Strumenti.DataModels.Tables
{
    public class A000014GuidaApplicativa : AbstractBaseDataModel
    {
        public int IdContesto { get; set; }

        public int IdFamiglia { get; set; }

        [ForeignKey(nameof(IdContesto))]
        public A000012Contesto Contesto { get; set; }

        [ForeignKey(nameof(IdFamiglia))]
        public A000013Famiglie Famiglia { get; set; }

        [InverseProperty(nameof(A000015EntitaGuidaApplicativa.GuidaApplicativa))]
        public ICollection<A000015EntitaGuidaApplicativa> EntitaGuidaApplicativa { get; set; }

        [InverseProperty(nameof(A000016OperazioniGuidaApplicativa.GuidaApplicativa))]
        public ICollection<A000016OperazioniGuidaApplicativa> OperazioniGuidaApplicativa { get; set; }
    }
}

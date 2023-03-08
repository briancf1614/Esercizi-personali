using Regolo2020.Base.DataModels;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Regolo2020.Ambienti.A00Strumenti.DataModels.Tables
{
    [Index(nameof(Famiglia), IsUnique = true)]
    [Index(nameof(CodiceFamiglia), IsUnique = true)]
    public class A000013Famiglie : AbstractBaseDataModel
    {
        public int IdContesto { get; set; }

        [MaxLength(50)]
        public string Famiglia { get; set; }

        [MaxLength(30)]
        public string CodiceFamiglia { get; set; }

        public int IdCodiceArchivio { get; set; }

        [MaxLength(100)]
        public string Descrizione { get; set; }

        public int IdFamigliaAnagrafica { get; set; }

        [ForeignKey(nameof(IdContesto))]
        public A000012Contesto Contesto { get; set; }

        [InverseProperty(nameof(A000014GuidaApplicativa.Famiglia))]
        public ICollection<A000014GuidaApplicativa> GuidaApplicativa { get; set; }

        [InverseProperty(nameof(A000023CartelleAutomatiche.Famiglia))]
        public ICollection<A000023CartelleAutomatiche> CartelleAutomatiche { get; set; }
    }
}

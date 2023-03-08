using Regolo2020.Base.DataModels;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Regolo2020.Ambienti.A00Strumenti.DataModels.Tables
{
    [Index(nameof(CodiceContesto), IsUnique = true)]
    public class A000012Contesto : AbstractBaseDataModel
    {
        [MaxLength(50)]
        public string Contesto { get; set; }

        [MaxLength(15)]
        public string CodiceContesto { get; set; }

        [MaxLength(100)]
        public string Descrizione { get; set; }

        [InverseProperty(nameof(A000013Famiglie.Contesto))]
        public ICollection<A000013Famiglie> Famiglie { get; set; }

        [InverseProperty(nameof(A000014GuidaApplicativa.Contesto))]
        public ICollection<A000014GuidaApplicativa> GuidaApplicativa { get; set; }
    }
}

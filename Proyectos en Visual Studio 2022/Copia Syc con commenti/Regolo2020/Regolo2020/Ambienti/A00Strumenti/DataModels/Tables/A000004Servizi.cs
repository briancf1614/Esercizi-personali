using Regolo2020.Base.DataModels;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Regolo2020.Ambienti.A00Strumenti.DataModels.Tables
{
    [Index(nameof(CodiceServizio), IsUnique = true)]
    public class A000004Servizi : AbstractBaseDataModel
    {
        public int IdEntita { get; set; }

        [MaxLength(50)]
        public string NomeServizio { get; set; }

        [MaxLength(11)]
        public string CodiceServizio { get; set; }

        [MaxLength(100)]
        public string Descrizione { get; set; }

        [MaxLength(50)]
        public string Namespace { get; set; }

        [ForeignKey(nameof(IdEntita))]
        public A000002Entita Entita { get; set; }

        [InverseProperty(nameof(A000015EntitaGuidaApplicativa.GuidaAIdServiziopplicativa))]
        public ICollection<A000015EntitaGuidaApplicativa> EntitaGuidaApplicativa { get; set; }
    }
}

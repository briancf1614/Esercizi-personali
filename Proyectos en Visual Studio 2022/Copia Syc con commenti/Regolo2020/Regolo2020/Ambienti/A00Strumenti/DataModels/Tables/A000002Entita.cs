using Regolo2020.Base.DataModels;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Regolo2020.Ambienti.A00Strumenti.DataModels.Tables
{
    [Index(nameof(CodiceEntita), IsUnique = true)]
    public class A000002Entita : AbstractBaseDataModel
    {
        public int IdAmbiente { get; set; }

        [MaxLength(50)]
        public string NomeEntita { get; set; }

        [MaxLength(7)]
        public string CodiceEntita { get; set; }

        [MaxLength(100)]
        public string Descrizione { get; set; }

        [ForeignKey(nameof(IdAmbiente))]
        public A000001AmbientiApplicativi Ambiente { get; set; }

        [InverseProperty(nameof(A000003Campi.CodiceEntita))]
        public ICollection<A000003Campi> Campi { get; set; }

        [InverseProperty(nameof(A000004Servizi.Entita))]
        public ICollection<A000004Servizi> Servizi { get; set; }

        [InverseProperty(nameof(A000015EntitaGuidaApplicativa.Entita))]
        public ICollection<A000015EntitaGuidaApplicativa> EntitaGuidaApplicativa { get; set; }
    }
}

using Regolo2020.Base.DataModels;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Regolo2020.Ambienti.A00Strumenti.DataModels.Tables
{
    [Index(nameof(CodiceApplicazione), IsUnique = true)]
    public class A000005Applicazioni : AbstractBaseDataModel
    {
        public int IdAmbienteApplicativo { get; set; }

        [MaxLength(50)]
        public string NomeApplicazione { get; set; }

        [MaxLength(7)]
        public string CodiceApplicazione { get; set; }

        [MaxLength(100)]
        public string Descrizione { get; set; }

        [ForeignKey(nameof(IdAmbienteApplicativo))]
        public A000001AmbientiApplicativi AmbienteApplicativo { get; set; }

        [InverseProperty(nameof(A000006Funzioni.Applicazione))]
        public ICollection<A000006Funzioni> Funzioni { get; set; }
    }
}

using Regolo2020.Base.DataModels;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Regolo2020.Ambienti.A00Strumenti.DataModels.Tables
{
    [Index(nameof(CodiceFunzione), IsUnique = true)]
    public class A000006Funzioni : AbstractBaseDataModel
    {
        public int IdApplicazione { get; set; }

        [MaxLength(50)]
        public string NomeFunzione { get; set; }

        [MaxLength(7)]
        public string CodiceFunzione { get; set; }

        [MaxLength(100)]
        public string Descrizione { get; set; }

        [ForeignKey(nameof(IdApplicazione))]
        public A000005Applicazioni Applicazione { get; set; }

        [InverseProperty(nameof(A000007Operazioni.Funzione))]
        public ICollection<A000007Operazioni> Operazioni { get; set; }
    }
}

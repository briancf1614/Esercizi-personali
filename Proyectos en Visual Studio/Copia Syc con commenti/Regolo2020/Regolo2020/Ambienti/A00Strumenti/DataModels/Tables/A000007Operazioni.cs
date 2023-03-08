using Regolo2020.Base.DataModels;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Regolo2020.Ambienti.A00Strumenti.DataModels.Tables
{
    [Index(nameof(CodiceOperazione), IsUnique = true)]
    public class A000007Operazioni : AbstractBaseDataModel
    {
        public int IdFunzione { get; set; }

        [MaxLength(50)]
        public string NomeOperazione { get; set; }

        [MaxLength(7)]
        public string CodiceOperazione { get; set; }

        [MaxLength(100)]
        public string Descrizione { get; set; }

        [ForeignKey(nameof(IdFunzione))]
        public A000006Funzioni Funzione { get; set; }

        [InverseProperty(nameof(A000016OperazioniGuidaApplicativa.Operazione))]
        public ICollection<A000016OperazioniGuidaApplicativa> OperazioniGuidaApplicativa { get; set; }
    }
}

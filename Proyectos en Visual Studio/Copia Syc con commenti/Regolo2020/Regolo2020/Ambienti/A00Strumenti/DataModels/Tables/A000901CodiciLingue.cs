using Regolo2020.Base.DataModels;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Regolo2020.Ambienti.A00Strumenti.DataModels.Tables
{
    [Index(nameof(CodiceLingua), IsUnique = true)]
    public class A000901CodiciLingue : AbstractBaseDataModel
    {
        [MaxLength(6)]
        public string CodiceLingua { get; set; }

        [MaxLength(100)]
        public string Descrizione { get; set; }
    }
}

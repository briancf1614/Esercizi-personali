using Regolo2020.Base.DataModels;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Regolo2020.Ambienti.A00Strumenti.DataModels.Tables
{
    public class A000023CartelleAutomatiche : AbstractBaseDataModel
    {
        public int IdFamiglia { get; set; }

        [MaxLength(100)]
        public string AnagraficaCartella { get; set; }

        public int IdCartellinaAutomatica { get; set; }

        [ForeignKey(nameof(IdFamiglia))]
        public A000013Famiglie Famiglia { get; set; }
    }
}

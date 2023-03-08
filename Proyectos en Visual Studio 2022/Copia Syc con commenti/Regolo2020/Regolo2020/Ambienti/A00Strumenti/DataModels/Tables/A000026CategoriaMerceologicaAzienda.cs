using Regolo2020.Base.DataModels;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Regolo2020.Ambienti.A00Strumenti.DataModels.Tables
{
    public class A000026CategoriaMerceologicaAzienda : AbstractBaseDataModel
    {
        [MaxLength(6)]
        public string CodiceCategoria { get; set; }

        [MaxLength(100)]
        public string NomeCategoriaMerceologica { get; set; }
    }
}

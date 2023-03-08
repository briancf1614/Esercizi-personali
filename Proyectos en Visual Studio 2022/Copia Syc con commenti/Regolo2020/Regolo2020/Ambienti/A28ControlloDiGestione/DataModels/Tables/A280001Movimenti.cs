using Regolo2020.Base.DataModels;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Regolo2020.Ambienti.A28ControlloDiGestione.DataModels.Tables
{
	public class A280001Movimenti : AbstractBaseDataModel
	{
		//[ForeignKey(nameof(A010002ContestoRapportiSchedaDati))]
		public int IdControparte { get; set; }

		public DateTime DataRegistrazione { get; set; }

		[MaxLength(20)]
		public string NumeroMovimento { get; set; }

		public DateTime DataDocumento { get; set; }

		[MaxLength(50)]
		public string NumeroDocumentoContropartita { get; set; }

		public double Dare { get; set; }

		public double Avere { get; set; }

		[MaxLength(50)]
		public string Causale { get; set; }

		[MaxLength(200)]
		public string DescrizioneRiga { get; set; }

		[MaxLength(50)]
		public string NomeFile { get; set; }
	}
}
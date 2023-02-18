namespace EsempioDaButare.Entità
{
    public class Reparto
    {
        public int Id { get; set; }
        public string NomeReparto { get; set; } = null!;
        public int CapacitaDiLavoratori { get; set; }


        //Relazione con le tabelle
        public int FabricaId { get; set; }
        public Fabrica Fabrica { get; set; } = null!;
        
        public int SupervisoreId { get; set; }
        public Supervisore Supervisore { get; set; } = null!;

        public HashSet<Dipendente> Dipendenti { get; set; } = new HashSet<Dipendente>();
        public HashSet<Stagista> Stagisti { get; set; }=new HashSet<Stagista>();
        



        
    }
}

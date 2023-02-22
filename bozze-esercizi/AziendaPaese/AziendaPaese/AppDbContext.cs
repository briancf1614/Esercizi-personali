using AziendaPaese.Entita;
using Microsoft.EntityFrameworkCore;

namespace AziendaPaese
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }



        public DbSet<Azienda> Aziende => Set<Azienda>();
        public DbSet<Dipendente> Dipendenti => Set<Dipendente>();
        public DbSet<Stagista> Stagisti => Set<Stagista>();
        public DbSet<SupervisoreReparto> SupervisoriReparto => Set<SupervisoreReparto>();
        public DbSet<Reparto> Reparti => Set<Reparto>();
        public DbSet<BustaPaga> Bustepaghe => Set<BustaPaga>();
        public DbSet<Progetto> Progetti => Set<Progetto>();
        public DbSet<ReporteGiornaliero> ReportiGiornalieri => Set<ReporteGiornaliero>();

    }





}

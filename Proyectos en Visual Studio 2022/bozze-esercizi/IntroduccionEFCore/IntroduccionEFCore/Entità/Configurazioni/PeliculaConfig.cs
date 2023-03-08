using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IntroduccionEFCore.Entità.Configurazioni
{
    public class PeliculaConfig : IEntityTypeConfiguration<Pelicula>
    {
        public void Configure(EntityTypeBuilder<Pelicula> builder)
        {
            builder.Property(p=>p.Nome).HasMaxLength(20);
            builder.Property(p => p.DataUscita).HasColumnType("date");
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Test1.Entidades.Configuraciones
{
    public class PeliculaConfig : IEntityTypeConfiguration<Pelicula>
    {
        public void Configure(EntityTypeBuilder<Pelicula> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Titulo).HasMaxLength(10);
            builder.Property(p => p.FechaEstreno).HasColumnType("date");
        }
    }
}

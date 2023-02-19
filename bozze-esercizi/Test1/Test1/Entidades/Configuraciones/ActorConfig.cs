using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Test1.Entidades.Configuraciones
{
    public class ActorConfig : IEntityTypeConfiguration<Actor>
    {
        public void Configure(EntityTypeBuilder<Actor> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Nombre).HasMaxLength(10);
            builder.Property(a => a.Apellido).HasMaxLength(10);
            builder.Property(a => a.FechaNacimiento).HasColumnType("date");
            builder.Property(a=>a.Fortuna).HasPrecision(18, 2);
        }
    }
}

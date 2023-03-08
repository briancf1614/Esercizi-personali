using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IntroduccionEFCore.Entità.Configurazioni
{
    public class ActorConfig : IEntityTypeConfiguration<Actor>
    {
        public void Configure(EntityTypeBuilder<Actor> builder)
        {
            builder.Property(a => a.Nome).HasMaxLength(20);
            builder.Property(a => a.DataNascita).HasColumnType("date");
            builder.Property(a=>a.Fortuna).HasPrecision(18,2);
        }
    }
}

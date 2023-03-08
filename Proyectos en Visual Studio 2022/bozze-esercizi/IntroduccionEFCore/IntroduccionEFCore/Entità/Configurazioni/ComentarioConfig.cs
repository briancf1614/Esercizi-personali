using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IntroduccionEFCore.Entità.Configurazioni
{
    public class ComentarioConfig : IEntityTypeConfiguration<Comentario>
    {
        public void Configure(EntityTypeBuilder<Comentario> builder)
        {
            builder.Property(c => c.Contenuto).HasMaxLength(500);
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IntroduccionEFCore.Entità.Configurazioni
{
    public class PeliculaActorConfig : IEntityTypeConfiguration<PeliculaActor>
    {
        public void Configure(EntityTypeBuilder<PeliculaActor> builder)
        {
            //QUA QUELLO CHE FACCIO è INSERIRE DOPPIA PRIMARY KEY
            builder.HasKey(pa=>new {pa.ActorId,pa.PeliculaId});
        }
    }
}

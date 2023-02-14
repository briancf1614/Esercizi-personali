using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Esercizio1.Entità.Configurazioni
{
    public class Studente_Corso_Config : IEntityTypeConfiguration<Studente_Corso>
    {
        public void Configure(EntityTypeBuilder<Studente_Corso> builder)
        {
            builder.HasKey(StudCors => new { StudCors.StudenteId, StudCors.CorsoId });

        }
    }
}

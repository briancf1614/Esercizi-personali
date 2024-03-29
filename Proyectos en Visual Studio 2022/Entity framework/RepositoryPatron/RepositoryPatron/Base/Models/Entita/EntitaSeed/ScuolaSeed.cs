using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RepositoryPatron.Base.Models.Entita.EntitaSeed
{
    public class ScuolaSeed : IEntityTypeConfiguration<Scuola>
    {
        public void Configure(EntityTypeBuilder<Scuola> builder)
        {
            builder.HasData(
                new Scuola()
                {
                    Id = 1,
                    Name = "Camerana",
                    Indirizzo = "via ferdinand 2",
                    Citta = "Torino"

                });
        }
    }
}

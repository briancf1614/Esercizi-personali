using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFBase.Models.Entity
{
    public class UserSeed : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasData(
                new User() { Id = 1, Name = "Brian", Email = "brian@hotmail.com" },
                new User() { Id = 2, Name = "Paul", Email = "paul@hotmail.com" }
                );
        }
    }
}

using Journify.core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Journify.infrastructure.Configurations
{
    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasData(
                new User
                {
                    Id = Guid.Parse("d290f1ee-6c54-4b01-90e6-d701748f0851"),
                    Username = "testuser",
                    Email = "fasdfa@gmail.om",
                    PasswordHash = "AQAAAA",
                    CreatedAt = new DateTime(2024, 01, 01, 0, 0, 0, DateTimeKind.Utc),
                },
                new User
                {
                    Id = Guid.Parse("e13b5f1e-7c54-4b01-90e6-d701748f0852"),
                    Username = "anotheruser",
                    Email = "fasdfasdf@gmail.com",
                    PasswordHash = "AQAAABBB",
                    CreatedAt = new DateTime(2024, 01, 01, 0, 0, 0, DateTimeKind.Utc),
                }
                );
        }
    }
}

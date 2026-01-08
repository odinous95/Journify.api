using Journify.core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Journify.infrastructure.Configurations
{
    public class DailyJourneyConfig : IEntityTypeConfiguration<DailyJourney>
    {
        public void Configure(EntityTypeBuilder<DailyJourney> builder)
        {
            builder.HasData(

                new DailyJourney
                {
                    Id = Guid.Parse("11111111-1111-1111-1111-111111111111"),
                    UserId = Guid.Parse("d290f1ee-6c54-4b01-90e6-d701748f0851"),
                    CreatedAt = new DateTime(2024, 01, 01, 0, 0, 0, DateTimeKind.Utc),
                    JournyDate = new DateOnly(2024, 01, 01)
                },
                new DailyJourney
                {
                    Id = Guid.Parse("33333333-3333-3333-3333-333333333333"),
                    UserId = Guid.Parse("e13b5f1e-7c54-4b01-90e6-d701748f0852"),
                    CreatedAt = new DateTime(2024, 01, 01, 0, 0, 0, DateTimeKind.Utc),
                    JournyDate = new DateOnly(2024, 01, 01)
                }
             );
        }
    }
}

using Journify.core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Journify.infrastructure.Configurations
{
    public class StepConfig : IEntityTypeConfiguration<Step>
    {
        public void Configure(EntityTypeBuilder<Step> builder)
        {
            builder.HasData(
                new Step
                {
                    Id = Guid.Parse("a1b2c3d4-e5f6-4789-9012-3456789abcde"),
                    DailyJourneyId = Guid.Parse("11111111-1111-1111-1111-111111111111"),
                    Title = "Morning Meditation",
                    Description = "Start your day with a 10-minute meditation session.",
                    IsCompleted = false,
                    CreatedAt = new DateTime(2024, 01, 01, 0, 0, 0, DateTimeKind.Utc),
                    LastUpdatedAt = new DateTime(2024, 01, 01, 0, 0, 0, DateTimeKind.Utc)
                },
                new Step
                {
                    Id = Guid.Parse("f1e2d3c4-b5a6-4789-9012-3456789fedcb"),
                    DailyJourneyId = Guid.Parse("33333333-3333-3333-3333-333333333333"),
                    Title = "Evening Reflection",
                    Description = "Reflect on your day and jot down your thoughts in your journal.",
                    IsCompleted = false,
                    CreatedAt = new DateTime(2024, 01, 01, 0, 0, 0, DateTimeKind.Utc),
                    LastUpdatedAt = new DateTime(2024, 01, 01, 0, 0, 0, DateTimeKind.Utc)
                }
                );
        }
    }
}

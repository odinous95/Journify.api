namespace Journify.core.Entities
{
    public class Step
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid DailyJourneyId { get; set; }
        public string Title { get; set; } = "";
        public string Description { get; set; } = "";
        public bool IsCompleted { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime LastUpdatedAt { get; set; } = DateTime.UtcNow;
    }
}

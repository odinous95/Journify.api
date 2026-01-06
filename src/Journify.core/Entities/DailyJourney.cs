namespace Journify.core.Entities
{
    public class DailyJourney
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid UserId { get; set; }
        public User User { get; set; } = null!;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateOnly JournyDate { get; set; }
        public ICollection<Step> Entries { get; set; } = new List<Step>();
    }
}

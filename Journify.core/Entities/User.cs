using Journify.Core.Enums;

namespace Journify.core.Entities
{
    public class User
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string ExternalIdentifyProvider { get; private set; } = "";
        public string Username { get; private set; } = "";
        public string Email { get; private set; } = "";
        public UserRole Role { get; private set; } = UserRole.User;
        public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
        public ICollection<DailyJourney> Journeys { get; private set; } = new List<DailyJourney>();
    }
}

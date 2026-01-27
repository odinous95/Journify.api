namespace Journify.core.Entities
{
    public class User
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string ExternalIdentifyProvider { get; private set; } = "";
        public string Username { get; private set; } = "";
        public string Email { get; private set; } = "";
        public string Role { get; private set; } = "";
        public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
        public ICollection<DailyJourney> Journeys { get; private set; } = new List<DailyJourney>();
        private User() { }
        public User(string externalIdentifyProvider, string username, string email, string role)
        {
            ExternalIdentifyProvider = externalIdentifyProvider;
            Username = username;
            Email = email;
            Role = role;
        }
    }
}

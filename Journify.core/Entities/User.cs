namespace Journify.core.Entities
{
    public class User
    {
        public Guid Id { get; private set; } = default!;
        public string AuthSub { get; private set; } = default!;
        public string Username { get; private set; } = default!;
        public string Email { get; private set; } = default!;
        public bool EmailVerified { get; private set; } = false;
        public string Role { get; private set; } = "user";
        public DateTime CreatedAt { get; private set; }


        private User() { }

        private User(string authSub, string email, string username, bool emailVerified)
        {
            Id = Guid.NewGuid();
            AuthSub = authSub;
            Email = email;
            Username = username;
            EmailVerified = emailVerified;
            CreatedAt = DateTime.UtcNow;
        }

        public static User Create(string authSub, string email, string username, bool emailVerified)
            => new(authSub, email, username, emailVerified);
    }
}

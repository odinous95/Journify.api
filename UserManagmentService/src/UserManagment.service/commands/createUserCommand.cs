namespace UserManagment.service.commands
{
    public class UserCommand
    {
        public string ExternalIdentifyProvider { get; }
        public string Email { get; }
        public string Username { get; }

        public UserCommand(string externalIdentifyProvider, string email, string username)
        {
            ExternalIdentifyProvider = externalIdentifyProvider;
            Email = email;
            Username = username;
        }
    }

}

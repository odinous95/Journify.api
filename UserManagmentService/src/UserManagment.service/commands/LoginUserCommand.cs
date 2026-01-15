namespace UserManagment.service.commands
{
    public class LoginUserCommand
    {
        public string Email { get; }
        public string Password { get; }
        public LoginUserCommand(string email, string password)
        {
            Email = email;
            Password = password;
        }
    }
}

namespace UserManagment.Service.DTOs
{
    public sealed class AuthenticatedUserDto
    {
        public string ExternalIdentityId { get; }
        public string Email { get; }
        public string Name { get; }


        public AuthenticatedUserDto(string externalIdentityId, string email, string name)
        {
            ExternalIdentityId = externalIdentityId;
            Email = email;
            Name = name;

        }
    }
}

namespace SimpleShop.Application.ApplicationUser
{
    public class CurrentUser
    {
        private static readonly string _adminRole = "Admin";
        private static readonly string _ownerRole = "Owner";

        public CurrentUser(string id, string email, IEnumerable<string> roles)
        {
            Id = id;
            Email = email;
            Roles = roles;
        }

        public string Id { get; set; }
        public string Email { get; set; }
        public IEnumerable<string> Roles { get; }

        public bool IsInManagingRole
            => Roles.Contains(_adminRole) || 
            Roles.Contains(_ownerRole);
    }
}

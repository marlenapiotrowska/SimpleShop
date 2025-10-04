namespace SimpleShop.Application.ApplicationUser;

public class CurrentUser
{
    private const string _adminRole = "Admin";
    private const string _ownerRole = "Owner";

    public CurrentUser(string id, string name, string email, IEnumerable<string> roles)
    {
        Id = id;
        Name = name;
        Email = email;
        Roles = roles;
    }

    public string Id { get; }
    public string Name { get; }
    public string Email { get; }
    public IEnumerable<string> Roles { get; }

    public bool IsInManagingRole
        => Roles.Contains(_adminRole) ||
        Roles.Contains(_ownerRole);
}

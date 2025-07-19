using Microsoft.AspNetCore.Http;
using SimpleShop.Application.Exceptions;
using System.Security.Claims;

namespace SimpleShop.Application.ApplicationUser
{
    public interface IUserContext
    {
        CurrentUser GetCurrentUser(bool managingRole);
        CurrentUser? GetCurrentUser();
    }

    public class UserContext : IUserContext
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserContext(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public CurrentUser GetCurrentUser(bool managingRole)
        {
            var user = _httpContextAccessor?.HttpContext?.User
                ?? throw new InvalidOperationException("Context user is not present");

            if (user.Identity == null || !user.Identity.IsAuthenticated)
            {
                throw new UserNotFoundException();
            }

            if (managingRole && !IsInManagingRole(user))
            {
                throw new UserNotInManagingRoleException();
            }

            return CreateUser(user);
        }

        public CurrentUser? GetCurrentUser()
        {
            var user = _httpContextAccessor?.HttpContext?.User;

            if (user?.Identity == null || !user.Identity.IsAuthenticated)
            {
                return null;
            }

            return CreateUser(user);
        }

        private bool IsInManagingRole(ClaimsPrincipal user)
        {
            return user.IsInRole("Admin") || user.IsInRole("Owner");
        }

        private static CurrentUser CreateUser(ClaimsPrincipal user)
        {
            var id = user.FindFirst(c => c.Type == ClaimTypes.NameIdentifier)!.Value;
            var name = user.FindFirst(c => c.Type == ClaimTypes.Name)!.Value;
            var email = user.FindFirst(c => c.Type == ClaimTypes.Email)!.Value;
            var roles = user.Claims.Where(c => c.Type == ClaimTypes.Role).Select(c => c.Value);

            return new CurrentUser(id, name, email, roles);
        }
    }
}

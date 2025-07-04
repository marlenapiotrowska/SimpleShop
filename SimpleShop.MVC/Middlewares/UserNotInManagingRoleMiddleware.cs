using SimpleShop.Application.Exceptions;

public class UserNotInManagingRoleMiddleware
{
    private readonly RequestDelegate _next;

    public UserNotInManagingRoleMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (UserNotInManagingRoleException)
        {
            context.Response.Redirect("/Home/NoAccessForNotManagingRole");
        }
    }
}

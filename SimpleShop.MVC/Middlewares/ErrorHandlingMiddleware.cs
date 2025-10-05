using SimpleShop.Application.Exceptions;
using SimpleShop.Infrastructure.Exceptions;

namespace SimpleShop.MVC.Middlewares;

public class ErrorHandlingMiddleware : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next.Invoke(context);
        }
        catch (Exception ex)
        {
            switch (ex)
            {
                case EntityNotFoundException:
                    context.Response.StatusCode = StatusCodes.Status404NotFound;
                    context.Response.Redirect("/Shared/Error");
                    return;
                case UserNotFoundException:
                    context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                    context.Response.Redirect("/Identity/Account/Login");
                    return;
                case UserNotInManagingRoleException:
                    context.Response.StatusCode = StatusCodes.Status403Forbidden;
                    context.Response.Redirect("/Home/AccessDenied");
                    return;
                default:
                    context.Response.Redirect($"/Home/Error?message={ex.Message}");
                    return;
            }
        }
    }
}

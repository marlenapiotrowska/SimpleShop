using SimpleShop.Application.Exceptions;

namespace SimpleShop.MVC.Middlewares
{
    public class UserNotInManagingRoleMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next.Invoke(context);
            }
            catch (UserNotInManagingRoleException)
            {
                context.Response.Redirect("/Home/NoAccessForNotManagingRole");
            }
        }
    }
}
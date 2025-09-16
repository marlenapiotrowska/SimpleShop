using SimpleShop.Application.Exceptions;

namespace SimpleShop.MVC.Middlewares
{
    public class UserNotFoundMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next.Invoke(context);
            }
            catch (UserNotFoundException)
            {
                context.Response.Redirect("/Identity/Account/Login");
            }
        }
    }
}
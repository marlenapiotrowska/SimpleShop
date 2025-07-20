using SimpleShop.Infrastructure.Exceptions;

namespace SimpleShop.MVC.Middlewares
{
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
                        context.Response.StatusCode = 404;
                        await context.Response.WriteAsync(ex.Message);
                        context.Response.Redirect("/Shared/Error");
                        break;

                    default:
                        context.Response.Redirect($"/Home/Error?message={ex.Message}");
                        break;
                }

            }
        }
    }
}

using SimpleShop.Application.Exceptions;

public class UserNotFoundMiddleware
{
    private readonly RequestDelegate _next;

    public UserNotFoundMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (UserNotFoundException)
        {
            context.Response.Redirect("/Identity/Account/Login");
        }
    }
}

namespace SimpleShop.Application.Exceptions
{
    public class UserNotFoundException : InvalidOperationException
    {
        internal UserNotFoundException()
            : base("Current logged user was not found")
        {
        }
    }
}

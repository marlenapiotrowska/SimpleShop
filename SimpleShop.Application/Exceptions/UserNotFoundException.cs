namespace SimpleShop.Application.Exceptions;

public class UserNotFoundException : Exception
{
    internal UserNotFoundException()
        : base("Current logged user was not found")
    {
    }
}

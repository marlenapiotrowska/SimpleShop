namespace SimpleShop.Application.Exceptions;

public class UserNotInManagingRoleException : InvalidOperationException
{
    internal UserNotInManagingRoleException()
        : base("You are not in managing role. You have to be Admin or Owner")
    {
    }
}

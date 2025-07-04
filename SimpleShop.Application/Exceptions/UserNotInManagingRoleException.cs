namespace SimpleShop.Application.Exceptions
{
    public class UserNotInManagingRoleException : InvalidOperationException
    {
        public UserNotInManagingRoleException()
            : base("You are not in managing role. You have to be Admin or Owner")
        {
        }
    }
}

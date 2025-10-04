namespace SimpleShop.Application.Exceptions;

public class ShopNotEditableException : Exception
{
    internal ShopNotEditableException(string name, string userName)
        : base($"Shop {name} can not be edit by {userName}")
    {
    }
}

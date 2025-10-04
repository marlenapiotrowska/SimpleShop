namespace SimpleShop.Domain.Exceptions;

internal class EmptyValueException : InvalidOperationException
{
    internal EmptyValueException(string valueName)
        : base($"The value '{valueName}' cannot be null or empty.")
    {
    }
}

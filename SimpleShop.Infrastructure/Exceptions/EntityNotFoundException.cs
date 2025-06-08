namespace SimpleShop.Infrastructure.Exceptions
{
    public class EntityNotFoundException : Exception
    {
        internal EntityNotFoundException(string message)
            : base(message)
        { 
        }
    }
}

namespace SimpleShop.Application.Exceptions
{
    public class ProductAssignedToShopException : InvalidOperationException
    {
        internal ProductAssignedToShopException(IEnumerable<string> shopNames)
            : base($"Cannot delete product that is assigned to the following shops: {string.Join(", ", shopNames)}")
        {
        }
    }
}

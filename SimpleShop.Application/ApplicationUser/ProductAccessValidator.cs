using SimpleShop.Application.Exceptions;

namespace SimpleShop.Application.ApplicationUser
{
    internal interface IProductAccessValidator
    {
        void Validate();
    }

    internal class ProductAccessValidator : IProductAccessValidator
    {
        private readonly IUserContext _userContext;

        public ProductAccessValidator(IUserContext userContext)
        {
            _userContext = userContext;
        }

        public void Validate()
        {
            _ = _userContext.GetCurrentUser()
                ?? throw new UserNotFoundException();
        }
    }
}

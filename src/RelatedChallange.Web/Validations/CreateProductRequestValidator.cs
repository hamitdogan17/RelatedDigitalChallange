using FluentValidation;
using RelatedChallange.Web.Requests;

namespace RelatedChallange.Web.Validations
{
    public class CreateProductRequestValidator : AbstractValidator<CreateProductRequest>
    {
        public CreateProductRequestValidator()
        {
            RuleFor(request => request.Product.Name).NotNull();
            RuleFor(request => request.Product.UnitPrice).NotNull();
        }
    }
}

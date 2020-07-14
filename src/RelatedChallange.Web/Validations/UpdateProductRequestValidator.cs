using FluentValidation;
using RelatedChallange.Web.Requests;

namespace RelatedChallange.Web.Validations
{
    public class UpdateProductRequestValidator : AbstractValidator<UpdateProductRequest>
    {
        public UpdateProductRequestValidator()
        {
            RuleFor(request => request.Product).NotNull();
        }
    }
}

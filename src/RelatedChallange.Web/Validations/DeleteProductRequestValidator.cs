using FluentValidation;
using RelatedChallange.Web.Requests;

namespace RelatedChallange.Web.Validations
{
    public class DeleteProductRequestValidator : AbstractValidator<DeleteProductByIdRequest>
    {
        public DeleteProductRequestValidator()
        {
            RuleFor(request => request.Id).GreaterThan(0);
        }
    }
}

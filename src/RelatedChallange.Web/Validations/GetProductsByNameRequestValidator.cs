using FluentValidation;
using RelatedChallange.Web.Requests;

namespace RelatedChallange.Web.Validations
{
    public class GetProductsByNameRequestValidator : AbstractValidator<GetProductsByNameRequest>
    {
        public GetProductsByNameRequestValidator()
        {
            RuleFor(request => request.Name).NotNull();
        }
    }
}

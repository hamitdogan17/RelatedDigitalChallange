using FluentValidation;
using RelatedChallange.Web.Requests;

namespace RelatedChallange.Web.Validations
{
    public class GetProductByIdRequestValidator : AbstractValidator<GetProductByIdRequest>
    {
        public GetProductByIdRequestValidator()
        {
            RuleFor(request => request.Id).NotNull();
        }
    }
}

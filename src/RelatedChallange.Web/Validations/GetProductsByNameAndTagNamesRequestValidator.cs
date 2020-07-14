using FluentValidation;
using RelatedChallange.Web.Requests;

namespace RelatedChallange.Web.Validations
{
    public class GetProductsByNameAndTagNamesRequestValidator : AbstractValidator<GetProductsByNameAndTagNamesRequest>
    {
        public GetProductsByNameAndTagNamesRequestValidator()
        {
            RuleFor(request => request.Name).NotNull();
            RuleFor(request => request.TagNameList).NotNull();
        }
    }
}

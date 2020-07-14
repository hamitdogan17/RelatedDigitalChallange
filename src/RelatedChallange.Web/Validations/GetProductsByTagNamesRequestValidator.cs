using FluentValidation;
using RelatedChallange.Web.Requests;

namespace RelatedChallange.Web.Validations
{
    public class GetProductsByTagNamesRequestValidator : AbstractValidator<GetProductsByTagNamesRequest>
    {
        public GetProductsByTagNamesRequestValidator()
        {
            RuleFor(request => request.TagNameList).NotNull();
        }
    }
}

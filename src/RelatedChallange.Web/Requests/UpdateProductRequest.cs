using MediatR;
using RelatedChallange.Application.Responses;

namespace RelatedChallange.Web.Requests
{
    public class UpdateProductRequest : IRequest<ProductModel>
    {
        public ProductModel Product { get; set; }
    }
}

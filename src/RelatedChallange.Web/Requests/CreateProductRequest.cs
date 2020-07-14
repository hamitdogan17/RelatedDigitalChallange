using MediatR;
using RelatedChallange.Application.Responses;


namespace RelatedChallange.Web.Requests
{
    public class CreateProductRequest : IRequest<ProductModel>
    {
        public ProductModel Product { get; set; }
    }
}

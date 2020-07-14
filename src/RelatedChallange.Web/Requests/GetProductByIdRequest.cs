using MediatR;
using RelatedChallange.Application.Responses;

namespace RelatedChallange.Web.Requests
{
    public class GetProductByIdRequest : IRequest<ProductModel>
    {
        public int Id { get; set; }
    }
}

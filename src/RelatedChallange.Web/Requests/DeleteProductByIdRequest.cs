using MediatR;

namespace RelatedChallange.Web.Requests
{
    public class DeleteProductByIdRequest : IRequest
    {
        public int Id { get; set; }
    }
}

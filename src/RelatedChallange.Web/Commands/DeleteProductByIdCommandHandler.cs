using MediatR;
using RelatedChallange.Web.Requests;
using RelatedChallange.Application.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace RelatedChallange.Web.Commands
{
    public class DeleteProductByIdCommandHandler : IRequestHandler<DeleteProductByIdRequest>
    {
        private readonly IProductService _productService;

        public DeleteProductByIdCommandHandler(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<Unit> Handle(DeleteProductByIdRequest request, CancellationToken cancellationToken)
        {
            await _productService.DeleteProductById(request.Id);

            return Unit.Value;
        }
    }
}

using MediatR;
using RelatedChallange.Web.Requests;
using RelatedChallange.Application.Interfaces;
using System.Threading;
using System.Threading.Tasks;
using RelatedChallange.Application.Responses;

namespace RelatedChallange.Web.Commands
{
    public class GetProductByIdCommandHandler : IRequestHandler<GetProductByIdRequest, ProductModel>
    {
        private readonly IProductService _productService;

        public GetProductByIdCommandHandler(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<ProductModel> Handle(GetProductByIdRequest request, CancellationToken cancellationToken)
        {
            var productModel = await _productService.GetProductById(request.Id);

            return productModel;
        }
    }
}

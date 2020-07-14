using MediatR;
using RelatedChallange.Web.Requests;
using RelatedChallange.Application.Interfaces;
using RelatedChallange.Application.Responses;
using System.Threading;
using System.Threading.Tasks;

namespace RelatedChallange.Web.Commands
{
    public class CreateProductCommandHandler
        : IRequestHandler<CreateProductRequest, ProductModel>
    {
        private readonly IProductService _productService;

        public CreateProductCommandHandler(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<ProductModel> Handle(CreateProductRequest request, CancellationToken cancellationToken)
        {
            var productModel = await _productService.CreateProduct(request.Product);

            return productModel;
        }
    }
}

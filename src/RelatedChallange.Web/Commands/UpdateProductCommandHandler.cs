using MediatR;
using RelatedChallange.Web.Requests;
using RelatedChallange.Application.Interfaces;
using RelatedChallange.Application.Responses;
using System.Threading;
using System.Threading.Tasks;

namespace RelatedChallange.Web.Commands
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductRequest, ProductModel>
    {
        private readonly IProductService _productService;

        public UpdateProductCommandHandler(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<ProductModel> Handle(UpdateProductRequest request, CancellationToken cancellationToken)
        {
            var productModel = await _productService.UpdateProduct(request.Product);

            return productModel;
        }
    }
}

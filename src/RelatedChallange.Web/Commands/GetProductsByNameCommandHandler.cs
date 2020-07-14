using MediatR;
using RelatedChallange.Web.Requests;
using RelatedChallange.Application.Interfaces;
using RelatedChallange.Application.Responses;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace RelatedChallange.Web.Commands
{
    public class GetProductsByNameCommandHandler
        : IRequestHandler<GetProductsByNameRequest, IEnumerable<ProductModel>>
    {
        private readonly IProductService _productService;

        public GetProductsByNameCommandHandler(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IEnumerable<ProductModel>> Handle(GetProductsByNameRequest request, CancellationToken cancellationToken)
        {
            var products = await _productService.GetProductsByName(request.Name);

            return products;
        }
    }
}

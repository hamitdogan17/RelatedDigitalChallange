using MediatR;
using RelatedChallange.Web.Requests;
using RelatedChallange.Application.Interfaces;
using RelatedChallange.Application.Responses;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace RelatedChallange.Web.Commands
{
    public class GetProductsByTagNamesCommandHandler
        : IRequestHandler<GetProductsByTagNamesRequest, IEnumerable<ProductModel>>
    {
        private readonly IProductService _productService;

        public GetProductsByTagNamesCommandHandler(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IEnumerable<ProductModel>> Handle(GetProductsByTagNamesRequest request, CancellationToken cancellationToken)
        {
            var products = await _productService.GetProductsByTagNames(request.TagNameList);

            return products;
        }
    }
}

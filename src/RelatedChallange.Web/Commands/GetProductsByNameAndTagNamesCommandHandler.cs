using MediatR;
using RelatedChallange.Web.Requests;
using RelatedChallange.Application.Interfaces;
using RelatedChallange.Application.Responses;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace RelatedChallange.Web.Commands
{
    public class GetProductsByNameAndTagNamesCommandHandler
        : IRequestHandler<GetProductsByNameAndTagNamesRequest, IEnumerable<ProductModel>>
    {
        private readonly IProductService _productService;

        public GetProductsByNameAndTagNamesCommandHandler(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IEnumerable<ProductModel>> Handle(GetProductsByNameAndTagNamesRequest request, CancellationToken cancellationToken)
        {
            var products = await _productService.GetProductsByNameAndTagNames(request.Name, request.TagNameList);

            return products;
        }
    }
}

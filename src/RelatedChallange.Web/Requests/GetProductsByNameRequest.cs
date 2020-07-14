using MediatR;
using RelatedChallange.Application.Responses;
using System.Collections;
using System.Collections.Generic;

namespace RelatedChallange.Web.Requests
{
    public class GetProductsByNameRequest : IRequest<IEnumerable<ProductModel>>
    {
        public string Name { get; set; }
    }
}

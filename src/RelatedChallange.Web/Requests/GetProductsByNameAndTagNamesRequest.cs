using MediatR;
using RelatedChallange.Application.Responses;
using System.Collections.Generic;

namespace RelatedChallange.Web.Requests
{
    public class GetProductsByNameAndTagNamesRequest : IRequest<IEnumerable<ProductModel>>
    {
        public string Name { get; set; }
        public IList<string> TagNameList { get; set; }
    }
}

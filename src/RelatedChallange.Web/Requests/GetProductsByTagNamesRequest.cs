using MediatR;
using RelatedChallange.Application.Responses;
using System.Collections.Generic;

namespace RelatedChallange.Web.Requests
{
    public class GetProductsByTagNamesRequest : IRequest<IEnumerable<ProductModel>>
    {
        public IList<string> TagNameList { get; set; }
    }
}

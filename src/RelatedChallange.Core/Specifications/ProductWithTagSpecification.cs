using RelatedChallange.Core.Entities;
using RelatedChallange.Core.Specifications.Base;
using System.Collections.Generic;
using System.Linq;

namespace RelatedChallange.Core.Specifications
{
    public class ProductWithTagSpecification : BaseSpecification<Product>
    {
        public ProductWithTagSpecification(int productId)
        : base(p => p.Id == productId)
            {
                AddInclude(p => p.Tags);
        }
        public ProductWithTagSpecification(string productName)
        : base(p => p.Name.ToLower().Contains(productName.ToLower()))
        {
            AddInclude(p => p.Tags);
        }

        public ProductWithTagSpecification(string productName, IList<string> requestedTags)
            : base(p => p.Name.ToLower().Contains(productName.ToLower()) && p.Tags.Any(t => requestedTags.Any(r => r == t.Name)))
        {
            AddInclude(p => p.Tags);
        }

        public ProductWithTagSpecification()
            : base(null)
        {
            AddInclude(p => p.Tags);
        }

        public ProductWithTagSpecification(IList<string> requestedTags)
            : base(p => p.Tags.Any(t => requestedTags.Any(r => r == t.Name)))
        {
            AddInclude(p => p.Tags);
        }
    }
}

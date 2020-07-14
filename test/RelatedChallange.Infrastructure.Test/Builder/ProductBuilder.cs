using RelatedChallange.Core.Entities;
using System.Collections.Generic;

namespace RelatedChallange.Infrastructure.Test.Builder
{
    public class ProductBuilder
    {
        public int TestProductId => 5;
        public string TestProductName => "Test Product Name";
        private TagBuilder TagBuilder { get; } = new TagBuilder();

        public ProductBuilder()
        {
            WithDefaultValues();
        }

        public Product WithDefaultValues()
        {
            List<Tag> tagList = new List<Tag>();
            tagList.Add(TagBuilder.TagWithDefaultValues());
            return Product.Create(TestProductId, TestProductName, tagList);
        }
    }
}

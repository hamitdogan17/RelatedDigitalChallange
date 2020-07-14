using RelatedChallange.Core.Entities.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RelatedChallange.Core.Entities
{
    public class Product : Entity
    {
        [Required, StringLength(80)]
        public string Name { get; set; }
        public decimal? UnitPrice { get; set; }
        public IList<Tag> Tags { get; set; }

        public static Product Create(int productId, string name, IList<Tag> tags, decimal unitPrice = 0)
        {
            var product = new Product
            {
                Id = productId,
                Name = name,
                UnitPrice = unitPrice,
                Tags = tags
            };
            return product;
        }
    }
}

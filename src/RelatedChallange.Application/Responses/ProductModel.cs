using System.Collections.Generic;

namespace RelatedChallange.Application.Responses
{
    public class ProductModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal? UnitPrice { get; set; }
        public IList<TagModel> Tags { get; set; }
    }
}

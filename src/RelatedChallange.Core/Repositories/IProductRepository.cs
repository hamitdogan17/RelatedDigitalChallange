using RelatedChallange.Core.Entities;
using RelatedChallange.Core.Repositories.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RelatedChallange.Core.Repositories
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<IEnumerable<Product>> GetProductListAsync();
        Task<IEnumerable<Product>> GetProductsByName(string name);
        Task<IEnumerable<Product>> GetProductsByTagNames(IList<string> tagNames);
        Task<IEnumerable<Product>> GetProductsByNameAndTagNames(string name, IList<string> tagNames);
        Task<Product> GetProductById(int productId);
        Task<Product> UpdateProduct(Product product);
        Task DeleteProduct(int productId);
    }
}

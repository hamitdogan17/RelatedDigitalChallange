using RelatedChallange.Application.Responses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RelatedChallange.Application.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductModel>> GetProductList();
        Task<ProductModel> GetProductById(int productId);
        Task<IEnumerable<ProductModel>> GetProductsByName(string name);
        Task<IEnumerable<ProductModel>> GetProductsByTagNames(IList<string> tagNames);
        Task<IEnumerable<ProductModel>> GetProductsByNameAndTagNames(string name, IList<string> tagNames);
        Task<ProductModel> CreateProduct(ProductModel product);
        Task<ProductModel> UpdateProduct(ProductModel product);
        Task DeleteProductById(int productId);
    }
}

using RelatedChallange.Application.Interfaces;
using RelatedChallange.Application.Responses;
using RelatedChallange.Core.Interfaces;
using RelatedChallange.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RelatedChallange.Application.Mapper;
using RelatedChallange.Core.Entities;

namespace RelatedChallange.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IAppLogger<ProductService> _logger;

        public ProductService(IProductRepository productRepository, IAppLogger<ProductService> logger)
        {
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<IEnumerable<ProductModel>> GetProductList()
        {
            var productList = await _productRepository.GetProductListAsync();

            var ProductModels = ObjectMapper.Mapper.Map<IEnumerable<ProductModel>>(productList);

            return ProductModels;
        }

        public async Task<ProductModel> GetProductById(int productId)
        {
            var product = await _productRepository.GetProductById(productId);

            var ProductModel = ObjectMapper.Mapper.Map<ProductModel>(product);

            return ProductModel;
        }

        public async Task<IEnumerable<ProductModel>> GetProductsByName(string name)
        {
            var productList = await _productRepository.GetProductsByName(name);

            var ProductModels = ObjectMapper.Mapper.Map<IEnumerable<ProductModel>>(productList);

            return ProductModels;
        }

        public async Task<IEnumerable<ProductModel>> GetProductsByTagNames(IList<string> tagNames)
        {
            var productList = await _productRepository.GetProductsByTagNames(tagNames);

            var ProductModels = ObjectMapper.Mapper.Map<IEnumerable<ProductModel>>(productList);

            return ProductModels;
        }
        public async Task<IEnumerable<ProductModel>> GetProductsByNameAndTagNames(string name, IList<string> tagNames)
        {
            var productList = await _productRepository.GetProductsByNameAndTagNames(name, tagNames);

            var ProductModels = ObjectMapper.Mapper.Map<IEnumerable<ProductModel>>(productList);

            return ProductModels;
        }

        public async Task<ProductModel> CreateProduct(ProductModel product)
        {
            var existingProduct = await _productRepository.GetByIdAsync(product.Id);
            if (existingProduct != null)
            {
                throw new ApplicationException("Product with this id already exists");
            }

            var newProduct = ObjectMapper.Mapper.Map<Product>(product);
            
            newProduct = await _productRepository.SaveAsync(newProduct);

            _logger.LogInformation("Entity successfully added - ProductService");

            var newProductModel = ObjectMapper.Mapper.Map<ProductModel>(newProduct);
            return newProductModel;
        }

        public async Task<ProductModel> UpdateProduct(ProductModel product)
        {
            var newProduct = ObjectMapper.Mapper.Map<Product>(product);

            await _productRepository.UpdateProduct(newProduct);

            var newProductModel = ObjectMapper.Mapper.Map<ProductModel>(product);
            return newProductModel;
        }

        public async Task DeleteProductById(int productId)
        {
            await _productRepository.DeleteProduct(productId);

            _logger.LogInformation("Entity successfully deleted - AspnetRunAppService");
        }
    }
}

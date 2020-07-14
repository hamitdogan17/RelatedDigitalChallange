//using RelatedChallange.Application.Exceptions;
using RelatedChallange.Application.Services;
using RelatedChallange.Core.Entities;
using RelatedChallange.Core.Interfaces;
using RelatedChallange.Core.Repositories;
using RelatedChallange.Core.Repositories.Base;
using Moq;
using System.Threading.Tasks;
using Xunit;
using System.Collections.Generic;
using RelatedChallange.Application.Responses;
using System;

namespace RelatedChallange.Application.Tests.Services
{
    public class ProductServiseTests
    {
        private Mock<IProductRepository> _mockProductRepository;
        private Mock<IAppLogger<ProductService>> _mockAppLogger;

        public ProductServiseTests()
        {
            _mockProductRepository = new Mock<IProductRepository>();
            _mockAppLogger = new Mock<IAppLogger<ProductService>>();
        }

        [Fact]
        public async Task GetProductList_Test()
        {
            var product1 = Product.Create(It.IsAny<int>(), It.IsAny<string>(), It.IsAny<IList<Tag>>());
            var product2 = Product.Create(It.IsAny<int>(), It.IsAny<string>(), It.IsAny<IList<Tag>>());

            _mockProductRepository.Setup(x => x.GetProductListAsync()).ReturnsAsync(new List<Product> { product1, product2 });

            var productService = new ProductService(_mockProductRepository.Object, _mockAppLogger.Object);
            var productList = await productService.GetProductList();

            _mockProductRepository.Verify(x => x.GetProductListAsync(), Times.Once);
        }

        [Fact]
        public async Task GetProductById_Test()
        {
            var product1 = Product.Create(It.IsAny<int>(), It.IsAny<string>(), It.IsAny<IList<Tag>>());

            _mockProductRepository.Setup(x => x.GetProductById(It.IsAny<int>())).ReturnsAsync(product1);

            var productService = new ProductService(_mockProductRepository.Object, _mockAppLogger.Object);
            var productList = await productService.GetProductById(It.IsAny<int>());

            _mockProductRepository.Verify(x => x.GetProductById(It.IsAny<int>()), Times.Once);
        }

        [Fact]
        public async Task GetProductsByName_Test()
        {
            var product1 = Product.Create(It.IsAny<int>(), It.IsAny<string>(), It.IsAny<IList<Tag>>());
            var existingProducts = new List<Product> { product1 };

            _mockProductRepository.Setup(x => x.GetProductsByName(It.IsAny<string>())).ReturnsAsync(existingProducts);

            var productService = new ProductService(_mockProductRepository.Object, _mockAppLogger.Object);
            var productList = await productService.GetProductsByName(It.IsAny<string>());

            _mockProductRepository.Verify(x => x.GetProductsByName(It.IsAny<string>()), Times.Once);
        }

        [Fact]
        public async Task CreateProductFail_Test()
        {
            var existingProduct = new Product();

            _mockProductRepository.Setup(x => x.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(existingProduct);

            var productService = new ProductService(_mockProductRepository.Object, _mockAppLogger.Object);

            await Assert.ThrowsAsync<ApplicationException>(() => productService.CreateProduct(new ProductModel { Id = 3 }));
        }

        [Fact]
        public async Task CreateProductSuccess_Test()
        {
            var existingProduct = new Product();

            _mockProductRepository.Setup(x => x.GetByIdAsync(It.IsAny<int>())).ReturnsAsync((Product)null);

            var productService = new ProductService(_mockProductRepository.Object, _mockAppLogger.Object);

            var productList = await productService.CreateProduct(new ProductModel { Id = 0 });

            _mockProductRepository.Verify(x => x.SaveAsync(It.IsAny<Product>()), Times.Once);

        }
    }
}

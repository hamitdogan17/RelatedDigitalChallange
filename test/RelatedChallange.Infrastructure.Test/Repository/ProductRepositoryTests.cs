using Microsoft.EntityFrameworkCore;
using RelatedChallange.Core.Entities;
using RelatedChallange.Infrastructure.Data;
using RelatedChallange.Infrastructure.Repository;
using RelatedChallange.Infrastructure.Test.Builder;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace RelatedChallange.Infrastructure.Test.Repository
{
    public class ProductRepositoryTests
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly ProductRepository _productRepository;
        private readonly ITestOutputHelper _output;
        private ProductBuilder ProductBuilder { get; } = new ProductBuilder();
        //private CategoryBuilder CategoryBuilder { get; } = new CategoryBuilder();

        public ProductRepositoryTests(ITestOutputHelper output)
        {
            _output = output;
            var dbOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "MoqApplicationDb")
                .Options;
            _applicationDbContext = new ApplicationDbContext(dbOptions);
            _productRepository = new ProductRepository(_applicationDbContext);
        }

        [Fact]
        public async Task GetProductListAsync_Test()
        {
            var product1 = ProductBuilder.WithDefaultValues();
            _applicationDbContext.Products.Add(product1);
            _applicationDbContext.SaveChanges();

            _output.WriteLine($"Product1: {product1.Name}");

            var productFromRepo = await _productRepository.GetProductListAsync();
            Assert.Equal(product1.Name, productFromRepo.FirstOrDefault().Name);
        }

        [Fact]
        public async Task UpdateProductFail_Test()
        {
            var existingProduct = ProductBuilder.WithDefaultValues();
            existingProduct.Name = "Test";

            var productId = existingProduct.Id;
            _output.WriteLine($"ProductId: {productId}");


            var productFromRepo = await _productRepository.UpdateProduct(existingProduct);
            Assert.Equal(existingProduct.Name, productFromRepo.Name);
        }
    }
}

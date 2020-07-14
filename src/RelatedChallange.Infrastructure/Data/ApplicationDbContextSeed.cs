using RelatedChallange.Core.Entities;
using RelatedChallange.Core.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RelatedChallange.Infrastructure.Data
{
    public class ApplicationDbContextSeed
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private IProductRepository _productRepository;

        public ApplicationDbContextSeed(
            ApplicationDbContext applicationDbContext,
            IProductRepository productRepository)
        {
            _applicationDbContext = applicationDbContext;
            _productRepository = productRepository;
        }
        public async Task SeedAsync()
        {
            _applicationDbContext.Database.EnsureCreated();
            await SeedProductsAsync();
        }

        private async Task SeedProductsAsync()
        {
            if (_applicationDbContext.Products.Any())
                return;

            var products = new List<Product>
            {
                // Phone
                new Product()
                {
                    Name = "Samsung Note 10",
                    UnitPrice = 295,
                    Tags =  new List<Tag>
                    {
                        new Tag
                        {
                            Name = "Green"
                        },

                        new Tag
                        {
                            Name = "35"
                        }
                    }
                },
                new Product()
                {
                    Name = "Xiaomi Mi Note 10",
                    UnitPrice = 285,
                    Tags =  new List<Tag>
                    {
                        new Tag
                        {
                            Name = "White"
                        },

                        new Tag
                        {
                            Name = "128GB"
                        }
                    }
                },
                new Product()
                {
                    Name = "Xiaomi Mi Note Lite",
                    UnitPrice = 285,
                    Tags =  new List<Tag>
                    {
                        new Tag
                        {
                            Name = "Black"
                        },

                        new Tag
                        {
                            Name = "64GB"
                        }
                    }
                },
                new Product()
                {
                    Name = "iPhone 11",
                    UnitPrice = 285,
                    Tags =  new List<Tag>
                    {
                        new Tag
                        {
                            Name = "Black"
                        },

                        new Tag
                        {
                            Name = "128GB"
                        }
                    }
                },
            };

            await _productRepository.AddRangeAsync(products);            
        }
    }
}

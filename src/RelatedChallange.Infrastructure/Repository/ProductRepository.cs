using Microsoft.EntityFrameworkCore;
using RelatedChallange.Core.Entities;
using RelatedChallange.Core.Repositories;
using RelatedChallange.Core.Specifications;
using RelatedChallange.Infrastructure.Data;
using RelatedChallange.Infrastructure.Repository.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RelatedChallange.Infrastructure.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(ApplicationDbContext context)
            : base(context)
        {
        }

        public async Task<IEnumerable<Product>> GetProductListAsync()
        {
            var spec = new ProductWithTagSpecification();
            return await GetAsync(spec);
        }

        public async Task<IEnumerable<Product>> GetProductsByName(string name)
        {
            var spec = new ProductWithTagSpecification(name);
            return await GetAsync(spec);
        }

        public async Task<IEnumerable<Product>> GetProductsByNameAndTagNames(string name, IList<string> tagNames)
        {
            var spec = new ProductWithTagSpecification(name, tagNames);
            return await GetAsync(spec);
        }

        public async Task<Product> GetProductById(int productId)
        {
            var spec = new ProductWithTagSpecification(productId);
            return (await GetAsync(spec)).FirstOrDefault();
        }

        public async Task<IEnumerable<Product>> GetProductsByTagNames(IList<string> tagNames)
        {
            var spec = new ProductWithTagSpecification(tagNames);
            return await GetAsync(spec);
        }

        public async Task<Product> UpdateProduct(Product product)
        {
            var existingProduct = await GetProductById(product.Id);
            if (existingProduct == null)
            {
                throw new ApplicationException("Product with this id is not exists");
            }

            // Update parent
            _dbContext.Entry(existingProduct).CurrentValues.SetValues(product);

            // Delete children
            foreach (var existingChild in existingProduct.Tags.ToList())
            {
                if (!product.Tags.Any(c => c.Id == existingChild.Id))
                    _dbContext.Entry(existingChild).State = EntityState.Deleted;
                    //_dbContext.Tags.Remove(existingChild);
            }

            foreach (var childModel in product.Tags)
            {
                var existingChild = existingProduct.Tags
                    .Where(c => c.Id == childModel.Id)
                    .SingleOrDefault();

                if (existingChild != null)
                    // Update child
                    _dbContext.Entry(existingChild).CurrentValues.SetValues(childModel);
                else
                {
                    // Insert child
                    var newChild = new Tag
                    {
                        Name = childModel.Name,
                        //...
                    };
                    existingProduct.Tags.Add(newChild);
                }
            }

            _dbContext.SaveChanges();

            return existingProduct;
        }

        public async Task DeleteProduct(int productId)
        {
            var existingProduct = await GetProductById(productId);
            if (existingProduct == null)
            {
                throw new ApplicationException("Product with this id is not exists");
            }

            foreach (var existingChild in existingProduct.Tags.ToList())
            {
                //_dbContext.Tags.Remove(existingChild);
                _dbContext.Entry(existingChild).State = EntityState.Deleted;
            }
            //_dbContext.Products.Remove(existingProduct);
            _dbContext.Entry(existingProduct).State = EntityState.Deleted;
            _dbContext.SaveChanges();
        }

        
    }
}


using BaseLibrary.Models;
using Microsoft.EntityFrameworkCore;
using ServerLibrary.Data;
using ServerLibrary.Repositories.IRepositories;

namespace ServerLibrary.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly IDbContextFactory<AppDbContext> _dbContextFactory;

        public ProductRepository(IDbContextFactory<AppDbContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public async Task<Product> CreateProductAsync(Product product)
        {
            using (AppDbContext context = _dbContextFactory.CreateDbContext())
            {
                await context.Products.AddAsync(product);
                var result = await context.SaveChangesAsync();

                if (result > 0)
                {
                    return await context.Products.FirstOrDefaultAsync(p => p.Name == product.Name);
                }

                return new Product();
            }
        }

        public async Task<bool> DeleteProductAsync(Guid id)
        {
            using (AppDbContext context = _dbContextFactory.CreateDbContext())
            {
                var product = await context.Products.FirstOrDefaultAsync(p => p.ProductId == id);

                context.Remove(product);
                var result = await context.SaveChangesAsync();

                return result > 0 ? true : false;
            }
        }

        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            using (AppDbContext context = _dbContextFactory.CreateDbContext())
            {
                return await context.Products.ToListAsync();
            }
        }

        public async Task<Product> GetProductByIdAsync(Guid id)
        {
            using (AppDbContext context = _dbContextFactory.CreateDbContext())
            {
                return await context.Products.FirstOrDefaultAsync(p => p.ProductId == id);
            }
        }

        public async Task<Product> GetProductByNameAsync(string name)
        {
            using (AppDbContext context = _dbContextFactory.CreateDbContext())
            {
                return await context.Products.FirstOrDefaultAsync(p => p.Name == name);
            }
        }

        public async Task<Product> UpdateProductAsync(Product product)
        {
            using (AppDbContext context = _dbContextFactory.CreateDbContext())
            {
                context.Products.Update(product);
                var result = await context.SaveChangesAsync();

                if (result > 0)
                {
                    return await context.Products.FirstOrDefaultAsync(p => p.Equals(product));
                }

                return product;
            }
        }

        public async Task<IEnumerable<Product>> GetProductsByBrandIdAsync(Guid brandId)
        {
            using (AppDbContext context = _dbContextFactory.CreateDbContext())
            {
                return await context.Products.Where(p => p.BrandId == brandId).ToListAsync();
            }
        }

        public async Task<bool> ExistsProductAsync(Guid id)
        {
            using (AppDbContext context = _dbContextFactory.CreateDbContext())
            {
                return await context.Products.AnyAsync(p => p.ProductId == id);
            }
        }

        public async Task<bool> ExistsProductAsync(string name)
        {
            using (AppDbContext context = _dbContextFactory.CreateDbContext())
            {
                return await context.Products.AnyAsync(p => p.Name == name);
            }
        }
    }
}

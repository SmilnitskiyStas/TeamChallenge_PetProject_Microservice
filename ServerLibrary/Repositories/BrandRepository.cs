
using BaseLibrary.Models;
using Microsoft.EntityFrameworkCore;
using ServerLibrary.Data;
using ServerLibrary.Repositories.IRepositories;

namespace ServerLibrary.Repositories
{
    public class BrandRepository : IBrandRepository
    {
        private readonly IDbContextFactory<AppDbContext> _dbContextFactory;

        public BrandRepository(IDbContextFactory<AppDbContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public async Task<Brand> CreateBrandAsync(Brand brand)
        {
            using (AppDbContext context = _dbContextFactory.CreateDbContext())
            {
                if (context.Brands.FirstOrDefault(b => b.Name == brand.Name) != null)
                {
                    return new Brand();
                }

                await context.Brands.AddAsync(brand);
                var result = await context.SaveChangesAsync();

                if (result > 0)
                {
                    return await context.Brands.FirstOrDefaultAsync(b => b.Name == brand.Name);
                }

                return new Brand();
            }
        }

        public async Task<bool> DeleteBrandAsync(Guid id)
        {
            using (AppDbContext context = _dbContextFactory.CreateDbContext())
            {
                Brand brand = await context.Brands.FirstOrDefaultAsync(b => b.BrandId == id);

                context.Brands.Remove(brand);

                var result = await context.SaveChangesAsync();

                return result > 0 ? true : false;
            }
        }

        public async Task<IEnumerable<Brand>> GetAllAsync()
        {
            using (AppDbContext context = _dbContextFactory.CreateDbContext())
            {
                return await context.Brands
                    .Include(p => p.Products)
                    .ToListAsync();
            }
        }

        public async Task<Brand> GetByIdAsync(Guid id)
        {
            using (AppDbContext context = _dbContextFactory.CreateDbContext())
            {
                Brand brand = await context.Brands.FirstOrDefaultAsync(b => b.BrandId == id);

                return brand;
            }
        }

        public async Task<Brand> GetByNameAsync(string name)
        {
            using (AppDbContext context = _dbContextFactory.CreateDbContext())
            {
                Brand brand = await context.Brands.FirstOrDefaultAsync(b => b.Name == name);

                return brand;
            }
        }

        public async Task<Brand> UpdateBrandAsync(Brand brand)
        {
            using (AppDbContext context = _dbContextFactory.CreateDbContext())
            {
                context.Brands.Update(brand);
                var result = await context.SaveChangesAsync();

                if (result > 0)
                {
                    return await context.Brands.FirstOrDefaultAsync(b => b.BrandId == brand.BrandId);
                }

                return new Brand();
            }
        }
    }
}

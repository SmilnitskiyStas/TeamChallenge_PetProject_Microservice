using BaseLibrary.Models;
using Microsoft.EntityFrameworkCore;
using ServerLibrary.Data;
using ServerLibrary.Repositories.IRepositories;

namespace ServerLibrary.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly IDbContextFactory<AppDbContext> _dbContextFactory;

        public CategoryRepository(IDbContextFactory<AppDbContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public async Task<Category> CreateCategoryAsync(Category category)
        {
            using (AppDbContext context = _dbContextFactory.CreateDbContext())
            {
                await context.AddAsync(category);
                var result = await context.SaveChangesAsync();

                if (result > 0)
                {
                    return await context.Categories.FirstOrDefaultAsync(c => c.Name == category.Name);
                }

                throw new ArgumentNullException(nameof(category));
            }
        }

        public async Task<bool> DeleteCategoryAsync(Guid id)
        {
            using (AppDbContext context = _dbContextFactory.CreateDbContext())
            {
                context.Remove(id);
                return await context.SaveChangesAsync() > 0 ? true : false;
            }
        }

        public async Task<bool> ExistsCategoryAsync(Guid id)
        {
            using (AppDbContext context = _dbContextFactory.CreateDbContext())
            {
                return await context.Categories.AnyAsync(c => c.CategoryId == id);
            }
        }

        public async Task<bool> ExistsCategoryAsync(string name)
        {
            using (AppDbContext context = _dbContextFactory.CreateDbContext())
            {
                return await context.Categories.AnyAsync(c => c.Name == name);
            }
        }

        public async Task<IEnumerable<Category>> GetCategoriesAsync()
        {
            using (AppDbContext context = _dbContextFactory.CreateDbContext())
            {
                return await context.Categories.ToListAsync();
            }
        }

        public async Task<IEnumerable<Category>> GetCategoriesByParentIdAsync(Guid parentId)
        {
            using (AppDbContext context = _dbContextFactory.CreateDbContext())
            {
                return await context.Categories.Where(c => c.ParentCategoryId == parentId).ToListAsync();
            }
        }

        public async Task<Category> GetCategoryByIdAsync(Guid id)
        {
            using (AppDbContext context = _dbContextFactory.CreateDbContext())
            {
                return await context.Categories.FirstOrDefaultAsync(c => c.CategoryId == id);
            }
        }

        public async Task<Category> GetCategoryByNameAsync(string name)
        {
            using (AppDbContext context = _dbContextFactory.CreateDbContext())
            {
                return await context.Categories.FirstOrDefaultAsync(c => c.Name == name);
            }
        }

        public async Task<Category> UpdateCategoryAsync(Category category)
        {
            using (AppDbContext context = _dbContextFactory.CreateDbContext())
            {
                context.Update(category);
                var result = await context.SaveChangesAsync();

                if (result > 0)
                {
                    return await context.Categories.FirstOrDefaultAsync(c => c.CategoryId == category.CategoryId);
                }

                throw new ArgumentNullException(nameof(category));
            }
        }
    }
}

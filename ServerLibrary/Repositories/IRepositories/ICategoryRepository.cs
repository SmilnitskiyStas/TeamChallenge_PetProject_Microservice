
using BaseLibrary.Models;

namespace ServerLibrary.Repositories.IRepositories
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetCategoriesAsync();
        Task<Category> GetCategoryByIdAsync(Guid id);
        Task<Category> GetCategoryByNameAsync(string name);
        Task<Category> CreateCategoryAsync(Category category);
        Task<Category> UpdateCategoryAsync(Category category);
        Task<bool> DeleteCategoryAsync(Guid id);
        Task<IEnumerable<Category>> GetCategoriesByParentIdAsync(Guid parentId);
        Task<bool> ExistsCategoryAsync(Guid id);
        Task<bool> ExistsCategoryAsync(string name);
    }
}

using BaseLibrary.Models;
using ServerLibrary.Repositories.IRepositories;

namespace Categories.Service.API.GraphQl.Queries
{
    public class CategoryQuery
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryQuery(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<IEnumerable<Category>> GetCategoriesAsync()
        {
            return await _categoryRepository.GetCategoriesAsync();
        }

        public async Task<Category> GetCategoryByIdAsync(Guid categoryId)
        {
            return await _categoryRepository.GetCategoryByIdAsync(categoryId);
        }

        public async Task<Category> GetCategoryByNameAsync(string categoryName)
        {
            return await _categoryRepository.GetCategoryByNameAsync(categoryName);
        }

        public async Task<IEnumerable<Category>> GetCategoriesByParentIdAsync(Guid parentId)
        {
            return await _categoryRepository.GetCategoriesByParentIdAsync(parentId);
        }
    }
}

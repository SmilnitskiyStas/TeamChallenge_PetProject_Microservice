
using BaseLibrary.Models;

namespace ServerLibrary.Repositories.IRepositories
{
    public interface IBrandRepository
    {
        Task<IEnumerable<Brand>> GetAllAsync();
        Task<Brand> GetByIdAsync(Guid id);
        Task<Brand> GetByNameAsync(string name);
        Task<Brand> CreateBrandAsync(Brand brand);
        Task<Brand> UpdateBrandAsync(Brand brand);
        Task<bool> DeleteBrandAsync(Guid id);

    }
}

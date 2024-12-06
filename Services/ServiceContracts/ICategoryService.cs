using _.Models;
namespace _.ServiceContracts;

public interface ICategoryService
{
    Task<IEnumerable<Category>> GetAllCategorysAsync();
    Task<Category> GetCategoryByIdAsync(int id);
    Task AddCategoryAsync(Category Category);
    Task UpdateCategoryAsync(Category Category);
    Task DeleteCategoryAsync(int id);
    Task<bool> CategoryExistsAsync(int id);
}

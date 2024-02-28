using ETour.DbRepos;
using ETour.DTO;
namespace ETour.Repository

{
    public interface ICategoryRepository
    {
        public Task<IEnumerable<Category>> getCategories();
        List<CategoryDTO> GetCategoriesWithSubCategoriesAndPackages();
        public  Task<Category> getCategoryById(int id);
    }
}

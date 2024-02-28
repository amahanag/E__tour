using Microsoft.AspNetCore.Mvc;
using ETour.DbRepos;
using Microsoft.EntityFrameworkCore;

namespace ETour.Repository
{
    public class SubCategoryRepository : ISubCategoryRepository
    {
        private readonly ScottDbContext context;

        public SubCategoryRepository(ScottDbContext context)
        {
            this.context = context;
        }

        public async Task<ActionResult<IEnumerable<SubCategory>?>> getSubcategories()
        {
            if(context.SubCategories == null)
            {
                return null;
            }
            return context.SubCategories.ToList();
        }

        //public async Task<ActionResult<IEnumerable<SubCategory>>> GetSubCategoriesById(int categoryId)
        //{
            
        //}

        public async Task<IEnumerable<SubCategory>> getSubCategoryById(int CategoryId)
        {
            var subcategory = context.SubCategories.FromSql($"select * from sub_category where category_id = {CategoryId}");
            return subcategory.ToList();
        }
    }
}

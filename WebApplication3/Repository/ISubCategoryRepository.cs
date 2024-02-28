using Microsoft.AspNetCore.Mvc;
using ETour.DbRepos;
using System.Collections;

namespace ETour.Repository
{
    public interface ISubCategoryRepository
    {
        public Task<ActionResult<IEnumerable<SubCategory>?>> getSubcategories();
        public Task<IEnumerable<SubCategory>> getSubCategoryById(int CategoryId);
    }
}

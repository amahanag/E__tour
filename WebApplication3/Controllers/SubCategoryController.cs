using Microsoft.AspNetCore.Mvc;
using ETour.DbRepos;
using ETour.Repository;

namespace ETour.Controllers
{
    [ApiController]
    [Route("/api/subcategory")]
    public class SubCategoryController : ControllerBase
    {
        private readonly ISubCategoryRepository repository;

        public SubCategoryController(ISubCategoryRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SubCategory>>> GetCategories()
        {
            var subcategories = await repository.getSubcategories();
            if (subcategories == null)
            {
                return NotFound();
            }
            return Ok(subcategories);
        }

        [HttpGet("{id}")]
        public async Task<IEnumerable<SubCategory>?> getcategorybyid(int id)
        {
            var subcategory = await repository.getSubCategoryById(id);  
            if (subcategory == null)
            {
                return null;
            }

            return subcategory;
        }

     
    }
}

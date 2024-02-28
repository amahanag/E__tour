using ETour.Repository;
using Microsoft.AspNetCore.Mvc;
using ETour.DbRepos;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ETour.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IternaryController : ControllerBase
    {

        private readonly IIternaryService _repository;

        public IternaryController(IIternaryService repository)
        {
            _repository = repository;

        }
        // GET: api/<IternaryController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Iternary>?>> GetEmployees()
        {
            if (await _repository.GetIternaryAsync() == null)
            {
                return NotFound();
            }

            return await _repository.GetIternaryAsync();
        }


        [HttpGet("{id}")]
        public async Task<IEnumerable<Iternary>> GetById_ActionResultOfT(int id)
        {
            var iternary = await _repository.GetIternaryByIdAsync(id);
            return iternary;
        }





    }
}

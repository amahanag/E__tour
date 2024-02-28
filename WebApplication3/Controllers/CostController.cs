using ETour.Repository;
using Microsoft.AspNetCore.Mvc;
using ETour.DbRepos;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ETour.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CostController : ControllerBase
    {

        private readonly ICostRepository _repository;

        public CostController(ICostRepository repository)
        {
            _repository = repository;

        }

        // GET api/<CostController>/5
        [HttpGet("{id}")]
        public async Task<IEnumerable<Cost>> GetById_ActionResultOfT(int id)
        {
            var cost = await _repository.GetCostById(id);
            return cost ;
        }

       






    }
}

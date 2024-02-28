using ETour.DbRepos;
using ETour.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ETour.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DateController : ControllerBase
    {
        private readonly IDateRepository dateRepository;

        public DateController(IDateRepository dateRepository)
        {
            this.dateRepository = dateRepository;

        }

      

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Date>?>> GetDates()
        {
            if (await dateRepository.getDates() == null)
            {
                return NotFound();
            }
            return await dateRepository.getDates();
        }

        [HttpGet("{id}")]
        public async Task<IEnumerable<Date>> getDateById(int id)
        {
            var date = await dateRepository.getDateById(id);
            return date;
        }
    }
}

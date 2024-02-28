using ETour.Repository;
using Microsoft.AspNetCore.Mvc;
using ETour.DbRepos;

namespace ETour.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PassengerController : ControllerBase
    {
        private readonly IPassengerRepository repository;

        public PassengerController(IPassengerRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Passenger>?>> GetPassenger()
        {
            if(await repository.GetAllPassenger() == null) 
            {
                return null;
            }
            return await repository.GetAllPassenger();
        }

        [HttpGet("{id}")]
        public async Task<IEnumerable<Passenger>> GetPassengerByid(int id)
        {
            var passenger= await repository.GetPassengerByid(id);
            if(passenger == null)
            {
                return null;
            }
            return passenger.Value;
        }

        [HttpPost]
        public async Task<ActionResult<Passenger>> CreatePassenger(Passenger passenger)
        {
            await repository.CreatePassenger(passenger);
            return CreatedAtAction(nameof(GetPassengerByid), new { id = passenger.PaxId}, passenger);
        }

    }
}

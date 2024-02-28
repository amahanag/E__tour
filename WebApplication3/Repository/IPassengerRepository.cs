using Microsoft.AspNetCore.Mvc;
using ETour.DbRepos;

namespace ETour.Repository
{
    public interface IPassengerRepository
    {

        Task<ActionResult<IEnumerable<Passenger>?>> GetPassengerByid(int Id);
       Task<ActionResult<IEnumerable<Passenger>?>>GetAllPassenger();

        Task CreatePassenger(Passenger passenger);

    }
}

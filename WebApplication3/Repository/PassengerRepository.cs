using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ETour.DbRepos;
using System.Security.Cryptography.X509Certificates;
using System;

namespace ETour.Repository
{
    public class PassengerRepository : IPassengerRepository
    {
        private readonly ScottDbContext _context;

        public PassengerRepository(ScottDbContext context)
        {
            _context = context;
        }

        public async Task CreatePassenger(Passenger passenger)
        {
            _context.Passengers.Add(passenger);
            await _context.SaveChangesAsync();

        }
        

        public  async Task<ActionResult<IEnumerable<Passenger>?>> GetAllPassenger()
        {
            if(_context.Passengers == null)
            {
                return null;
            }
            return await _context.Passengers.ToListAsync();
        }

         public async Task<ActionResult<IEnumerable<Passenger>?>> GetPassengerByid(int Id)
        {
            var passenger = await _context.Passengers.FromSql($"SELECT * FROM passenger WHERE customer_id={Id}")
                               .ToListAsync();
            return passenger;
        }
    }
}

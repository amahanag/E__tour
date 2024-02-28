using Microsoft.EntityFrameworkCore;
using ETour.DbRepos;
using System;

namespace ETour.Repository
{
    public class SQLCustomer : ICustomerRepository
    {

        private readonly ScottDbContext _context;

        public SQLCustomer(ScottDbContext context)
        {
            _context = context;
        }

        public async Task<List<Customer>> GetCustomers()
        {
            if(_context== null)
            {
                return null;
            }
            return await _context.Customers.ToListAsync();
        }

        public async Task CreateCustomer(Customer customers)
        {
            _context.Customers.Add(customers);
            await _context.SaveChangesAsync();
        }

       

        public async Task<Customer> GetCustomerById(int id)
        {
            return await _context.Customers.FindAsync(id);
        }

        public async Task<IEnumerable<Customer>?> GetCustomerByEmail(string email)
        {
            var customer = await _context.Customers.FromSql($"SELECT * FROM Customer WHERE email={email}")
                                        .ToListAsync();
            return customer;
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Core.Types;
using ETour.DbRepos;
using ETour.Repository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ETour.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {

        private readonly ICustomerRepository _customerRepository;

        public CustomerController(ICustomerRepository customerRepo)
        {
            _customerRepository = customerRepo ?? throw new ArgumentNullException(nameof(customerRepo));
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> GetCustomers()
        {
            var customers = await _customerRepository.GetCustomers();
            return Ok(customers);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> GetCustomerById(int id)
        {
            var customer = await _customerRepository.GetCustomerById(id);
            if (customer == null)
            {
                return NotFound();
            }
            return Ok(customer);
        }

        [HttpGet("{email}")]
        public async Task<ActionResult<IEnumerable<Customer>>> GetCustomerByEmail(String email)
        {
            var customer = await _customerRepository.GetCustomerByEmail(email);
            if (customer == null)
            {
                return NotFound();
            }
            return Ok(customer);

        }

        [HttpPost]
        public async Task<ActionResult<Customer>> CreateCustomer(Customer customer)
        {
            await _customerRepository.CreateCustomer(customer);
            return CreatedAtAction(nameof(GetCustomerById), new { id = customer.CustomerId }, customer);
        }

        
    }
}

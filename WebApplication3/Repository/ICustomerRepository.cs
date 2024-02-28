using ETour.DbRepos;

namespace ETour.Repository
{
    public interface ICustomerRepository
    {
        Task<List<Customer>> GetCustomers();
        Task<Customer> GetCustomerById(int id);
        Task<IEnumerable<Customer>?> GetCustomerByEmail(string name);
        Task CreateCustomer(Customer customers);
       
    }
}

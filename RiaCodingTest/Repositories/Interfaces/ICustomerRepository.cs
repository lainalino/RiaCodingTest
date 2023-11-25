using RiaCodingTest.API.Models;

namespace RiaCodingTest.API.Repositories.Interfaces
{
    public interface ICustomerRepository
    {
        Task<List<Customer>> InsertCustomer(List<Customer> listCustomer);
        Task<List<Customer>> GetCustomers();
    }
}

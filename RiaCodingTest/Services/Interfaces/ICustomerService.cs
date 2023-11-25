using RiaCodingTest.API.Models;

namespace RiaCodingTest.API.Services.Interfaces
{
    public interface ICustomerService
    {
        public Task<List<Customer>> InsertCustomer(List<Customer> listCustomer);
        public Task<List<Customer>> GetCustomer();
    }
}

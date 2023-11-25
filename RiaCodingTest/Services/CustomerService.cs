using RiaCodingTest.API.Services.Interfaces;
using RiaCodingTest.API.Models;

using RiaCodingTest.API.Repositories.Interfaces;

namespace RiaCodingTest.API.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        public CustomerService(ICustomerRepository customerRepository)
        {
            this._customerRepository = customerRepository;
        }
        public async Task<List<Customer>> InsertCustomer(List<Customer> listCustomer)
        {
           return await _customerRepository.InsertCustomer(listCustomer);
        }

        public async Task<List<Customer>> GetCustomer()
        {
            return await _customerRepository.GetCustomers();
        }
    }
}

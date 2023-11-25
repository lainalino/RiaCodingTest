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

        /// <summary> 
        /// The code inserts the client into the txt file.
        /// </summary>
        public async Task<List<Customer>> InsertCustomer(List<Customer> listCustomer)
        {
           return await _customerRepository.InsertCustomer(listCustomer);
        }

        /// <summary> 
        /// The code gets allt the client.
        /// </summary>
        public async Task<List<Customer>> GetCustomer()
        {
            return await _customerRepository.GetCustomers();
        }
    }
}

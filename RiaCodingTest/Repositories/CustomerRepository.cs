using RiaCodingTest.API.Models;
using RiaCodingTest.API.Repositories.Interfaces;
using RiaCodingTest.API.Services.Interfaces;
using System.Text.Json;

namespace RiaCodingTest.API.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly IStorageService _storageService;
        public CustomerRepository(IStorageService storageService)
        {
            this._storageService = storageService;
        }
        public async Task<List<Customer>> InsertCustomer(List<Customer> listCustomer)
        {
            try
            {

                List<Customer> _registeredCustomers = new List<Customer>();

                _registeredCustomers = await GetCustomers();

                IEnumerable<int> idRegistered = _registeredCustomers
                                            .Select(a => a.Id)
                                            .Intersect(listCustomer.Select(b => b.Id))
                                            .Distinct();

                if (idRegistered.Count() > 0)
                {
                    throw new Exception($"The Id(s): [ {string.Join(", ", idRegistered.Select(x => x))} ] already registered.");
                }

                foreach (Customer customer in listCustomer)
                {
                    var aux = _registeredCustomers;
                    var index = GetIndex(_registeredCustomers, customer);
                    if (index < 0) index = ~index;
                    _registeredCustomers.Insert(index, customer);
                }

                await _storageService.SaveCustomers(_registeredCustomers);

                return listCustomer;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<Customer>> GetCustomers()
        {
            try
            {
                List<Customer> _registeredCustomers = new List<Customer>();
                var customers = await _storageService.GetCustomers();

                if (!string.IsNullOrEmpty(customers))
                {
                    _registeredCustomers = JsonSerializer.Deserialize<List<Customer>>(customers);
                }

                return _registeredCustomers;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private int GetIndex(List<Customer> listCustomer, Customer addCustomer)
        {
            int index = 0;
            foreach (Customer customer in listCustomer)
            {
                int lastNameComparison = string.Compare(customer.LastName, addCustomer.LastName, StringComparison.OrdinalIgnoreCase);
                if (lastNameComparison > 0 || (lastNameComparison == 0 && string.Compare(customer.FirstName, addCustomer.FirstName, StringComparison.OrdinalIgnoreCase) > 0))
                {
                    return index;
                }
                index++;
            }
            return index;
        }

    }
}

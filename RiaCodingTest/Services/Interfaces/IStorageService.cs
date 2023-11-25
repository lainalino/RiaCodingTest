using RiaCodingTest.API.Models;

namespace RiaCodingTest.API.Services.Interfaces
{
    public interface IStorageService
    {
        public Task<string> GetCustomers();
        public Task SaveCustomers(ICollection<Customer> customers);
    }
}

using RiaCodingTest.API.Models;
using RiaCodingTest.API.Services.Interfaces;
using System.Text.Json;
using System.Text;
using System.IO;

namespace RiaCodingTest.API.Services
{
    public class StorageService : IStorageService
    {
        private readonly string _filePath = "./Files/Customers.txt";

        /// <summary> 
        /// The code gets allt the client.
        /// </summary>
        public async Task<string> GetCustomers()
        {
            if (File.Exists(_filePath))
            {
                using var reader = new StreamReader(_filePath);

                return await reader.ReadToEndAsync();
            }

            return string.Empty;
        }

        /// <summary> 
        /// The code inserts the client into the txt file.
        /// </summary>
        public async Task SaveCustomers(ICollection<Customer> customers)
        {
            if (!File.Exists(_filePath))
            {
                File.Create(_filePath).Close();
            }
            using var fs = new FileStream(_filePath, FileMode.Truncate, FileAccess.Write);
            using var sw = new StreamWriter(fs, Encoding.UTF8, bufferSize: 4096, leaveOpen: true);

            var customersString = JsonSerializer.Serialize(customers);
            await sw.WriteLineAsync(customersString);
            sw.Flush();
        }
    }
}

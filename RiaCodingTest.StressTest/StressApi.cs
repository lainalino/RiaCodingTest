using RiaCodingTest.API.Models;
using System.Net.Http;
using System.Text;
using System.Text.Json;

namespace RiaCodingTest.StressTest
{
    public class StressApi
    {
        public StressApi() { }
        private readonly string _URL = "https://localhost:7005";
       
        public async Task PostAsync(ICollection<Customer> customers)
        {
            using (var client = new HttpClient())
            {
                var body = JsonSerializer.Serialize(customers);
                var postMessage = new HttpRequestMessage(HttpMethod.Post, $"{_URL}/customers")
                {
                    Content = new StringContent(body, Encoding.UTF8, "application/json")
                };

                await client.SendAsync(postMessage);
            }

        }
    }
}

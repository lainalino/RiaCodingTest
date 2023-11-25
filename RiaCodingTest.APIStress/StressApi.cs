using RiaCodingTest.API.Models;
using System.Net.Http;
using System.Text;
using System.Text.Json;

namespace RiaCodingTest.APIStress
{
    public class StressApi
    {
        public StressApi() { }
        private readonly string _URL = "https://localhost:7073";
       
        public async Task<HttpResponseMessage> PostAsync(ICollection<Customer> customers)
        {
            using (var client = new HttpClient())
            {
                var body = JsonSerializer.Serialize(customers);
                var postMessage = new HttpRequestMessage(HttpMethod.Post, $"{_URL}/customer/insert")
                {
                    Content = new StringContent(body, Encoding.UTF8, "application/json")
                };

               return await client.SendAsync(postMessage);
            }
        }

        public async Task<List<Customer>> GetAsync()
        {
            var urlGet = new HttpRequestMessage(HttpMethod.Get, $"{_URL}/customer/get-all");
            
            using (var client = new HttpClient())
            {
                var response = await client.SendAsync(urlGet);

                return JsonSerializer.Deserialize<List<Customer>>(
                    await response.Content.ReadAsStringAsync(),
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    })!;
            }
        }
    }
}

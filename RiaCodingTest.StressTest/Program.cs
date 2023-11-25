using RiaCodingTest.API.Models;
using RiaCodingTest.StressTest;

StressApi stressApi = new StressApi();
List<Customer> customers = new List<Customer>();

await stressApi.PostAsync(customers);
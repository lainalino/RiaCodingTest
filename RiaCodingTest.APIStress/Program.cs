using OfficeOpenXml.FormulaParsing.Excel.Functions.Information;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Numeric;
using RiaCodingTest.API.Models;
using RiaCodingTest.APIStress;

StressApi stressApi = new StressApi();
List<Customer> listCustomers = new List<Customer>();

var batchSize = 500;

for (int i = 0; i < batchSize; i++)
{
    var tasks = Task.Run(() => stressApi.PostAsync(CustomerStress.GetCustomerRandom()));
    var taskGet = Task.Run(() => stressApi.GetAsync());
    await Task.WhenAll(tasks, taskGet);
}





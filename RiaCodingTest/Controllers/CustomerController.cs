using Microsoft.AspNetCore.Mvc;
using RiaCodingTest.API.Models;
using RiaCodingTest.API.Services.Interfaces;

namespace RiaCodingTest.API.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;
        public CustomerController(ICustomerService customerService)
        {
            this._customerService = customerService;
        }
        /// <summary> 
        /// 
        /// <param name="listCustomer"></param>
        /// </summary>
        [HttpPost]
        [Route("[controller]/insert")]
        public async Task<IActionResult> InsertCustomer([FromBody] List<Customer> listCustomer)
        {
            if (!ModelState.IsValid)
            {
                var errors = new List<string>();
                foreach (var state in ModelState)
                {
                    foreach (var error in state.Value.Errors)
                    {
                        errors.Add(error.ErrorMessage);
                    }
                }
                return BadRequest(errors);
            }
            
            var response = await _customerService.InsertCustomer(listCustomer);
            return Ok(response);
        }

        /// <summary> 
        /// 
        /// <param name="listCustomer"></param>
        /// </summary>
        [HttpGet]
        [Route("[controller]/get-all")]
        public async Task<IActionResult> GetCustomer()
        {
            var response = await _customerService.GetCustomer();
            return Ok(response);
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using RiaCodingTest.API.Services.Interfaces;

namespace RiaCodingTest.API.Controllers
{
    public class ATMController : Controller
    {
        private readonly IATMService _atmService;

        public ATMController(IATMService atmService)
        {
            _atmService = atmService;
        }

        /// <summary> 
        /// Get the possible combinations which the ATM can pay out using the notes 10, 50 and 100 
        /// <param name="amount"></param>
        /// </summary>
        [HttpGet]
        [Route("[controller]/get-denominations")]
        public async Task<IActionResult> GetDenominations(int amount)
        {
            var denominations = _atmService.GetDenominations(amount);
            return Ok(denominations);
        }
    }
}

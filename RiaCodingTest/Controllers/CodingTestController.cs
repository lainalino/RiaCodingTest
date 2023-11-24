﻿using Microsoft.AspNetCore.Mvc;
using RiaCodingTest.Services.Interfaces;

namespace RiaCodingTest.Controllers
{
    public class CodingTestController : Controller
    {
        private readonly IATMService _atmService;

        public CodingTestController(IATMService atmService)
        {
            _atmService = atmService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetDenominations(int amount)
        {
            var denominations = _atmService.GetDenominations(amount);
            return Ok(denominations);
        }

    }
}

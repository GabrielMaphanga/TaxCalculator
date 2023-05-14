using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

using System.Threading.Tasks;
using TaxCalculator.View.Models;
using TaxCalulator.Core.Entities;
using System.Net.Http.Json;
using System.Net.Http;
using TaxCalulator.Core.Utilities;

namespace TaxCalculator.View.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly HttpClient _httpClient;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            _httpClient = new HttpClient();
        }

        public IActionResult Index()
        {
           
            return View(new IndividualInput());
        }

        public async Task<IActionResult> Calculate(IndividualInput individualInput)
        {

            if (ModelState.IsValid)
            {
                //Make http call to CalculateTaxAPI
                var calculated = await _httpClient.PostAsJsonAsync("https://localhost:44380/Create", individualInput);
                var calculateMessage = calculated.Content.ReadAsStringAsync().Result;

                //Deserialize Tax value
                var calculatedAnnualTax = Util.Deserialize<CalculatedAnnualTax>(calculateMessage);


                return View(calculatedAnnualTax);
            }else
            {
                return View();
            }
                
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

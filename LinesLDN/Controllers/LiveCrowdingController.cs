using LinesLDN.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;

namespace LinesLDN.Controllers
{
    public class LiveCrowdingController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public LiveCrowdingController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> LiveCrowding(string station)
        {
            //Console.WriteLine(station);
            LiveCrowding liveCrowding = new LiveCrowding();
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://api.tfl.gov.uk");
            var getLiveCrowding = await client.GetAsync($"/crowding/{station}/Live");

            try
            {
                string results = await getLiveCrowding.Content.ReadAsStringAsync().ConfigureAwait(false);
                liveCrowding = JsonConvert.DeserializeObject<LiveCrowding>(results);
                //Console.WriteLine(liveCrowding);
                var liveData = liveCrowding.percentageOfBaseLine;
                //Console.WriteLine(liveData);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                if (ex.InnerException != null)
                {
                    Console.WriteLine($"Inner Exception: {ex.InnerException.Message}");
                }
                _logger.LogError(ex, "An error occurred during GetCrowdingResult");
                return StatusCode(500, "Internal Server Error");
            }

            ViewData.Model = liveCrowding;

            return View();
        }
    }
}

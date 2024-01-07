using LinesLDN.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.Text.Json.Serialization;
using static System.Collections.Specialized.BitVector32;

namespace LinesLDN.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public async Task<IActionResult> Index2()
        {
            StationStopPoints stations = new StationStopPoints();
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://api.tfl.gov.uk");
            var getStations = client.GetAsync("/StopPoint/Mode/tube");

            try
            {
                string results = await getStations.Result.Content.ReadAsStringAsync().ConfigureAwait(false);
                stations = JsonConvert.DeserializeObject<StationStopPoints>(results);
                Console.WriteLine(stations.stopPoints);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                if (ex.InnerException != null)
                {
                    Console.WriteLine($"Inner Exception: {ex.InnerException.Message}");
                }
            }

            var filteredStations = stations.stopPoints
                    .Where(station => station.stopType == "NaptanMetroStation")
                    .DistinctBy(station => station.commonName)
                    .OrderBy(station => station.commonName)
                    .ToList();

            ViewData.Model = filteredStations;

            return View();
        }

        public async Task<IActionResult> LineStatusInfo()
        {
            List<Lines> lines = new List<Lines>();
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://api.tfl.gov.uk");
            var getStations = client.GetAsync("/Line/Mode/tube/Status");

            try
            {
                string results = await getStations.Result.Content.ReadAsStringAsync().ConfigureAwait(false);
                //Console.WriteLine(results);
                lines = JsonConvert.DeserializeObject<List<Lines>>(results);
                //Console.WriteLine(lines);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                if (ex.InnerException != null)
                {
                    Console.WriteLine($"Inner Exception: {ex.InnerException.Message}");
                }
            }

            ViewData.Model = lines;

            return PartialView("_LineStatusInfo");
        }

        [HttpPost]
        [Route("Home/GetCrowdingResult")]
        public async Task<IActionResult> GetCrowdingResult(string station, string dayOfWeek)
        {
            CrowdingModel timeBandCrowding = new CrowdingModel();
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://api.tfl.gov.uk");
            var getTimeBands =   await client.GetAsync($"/crowding/{station}/{dayOfWeek}");
            //Console.WriteLine(getTimeBands.Content);
            try
            {
                string results = await getTimeBands.Content.ReadAsStringAsync().ConfigureAwait(false);
                //Console.WriteLine(results);
                timeBandCrowding = JsonConvert.DeserializeObject<CrowdingModel>(results);
                //Console.WriteLine(timeBandCrowding);
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
            ViewData.Model = timeBandCrowding;
            return View();
        }
    }
}

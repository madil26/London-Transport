using AngularAirlineSite.ReadModels;
using Microsoft.AspNetCore.Mvc;

namespace AngularAirlineSite.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FlightController : ControllerBase
    {
    
        private readonly ILogger<FlightController> _logger;

        public FlightController(ILogger<FlightController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<FlightRm> Search()
            => new FlightRm[]
            {
                "Pak Air",
                "jdnfs Air",
            };
    }
}
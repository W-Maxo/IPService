using Microsoft.AspNetCore.Mvc;
using AspNetCoreRateLimit;

namespace IPService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RemoteIpController : ControllerBase
    {
        //private static readonly string[] Summaries = new[]
        //{
        //    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        //};

        private readonly ILogger<RemoteIpController> _logger;

        public RemoteIpController(ILogger<RemoteIpController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetRemoteIpAddress")]
        //[RateLimit("EndpointRateLimitPolicy")]
        public RemoteIp? Get()
        {
            //var ipAddress = ;

            return new RemoteIp() { ipAddress = HttpContext.Connection.RemoteIpAddress?.ToString() };

            //return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            //{
            //    Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            //    TemperatureC = Random.Shared.Next(-20, 55),
            //    Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            //})
            //.ToArray();
        }
    }
}

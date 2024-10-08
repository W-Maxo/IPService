using Microsoft.AspNetCore.Mvc;
using AspNetCoreRateLimit;
using System.Net.Sockets;
using System.Net;

namespace IPService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RemoteIpController : ControllerBase
    {
        private readonly ILogger<RemoteIpController> _logger;

        public RemoteIpController(ILogger<RemoteIpController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetRemoteIpAddress")]
        //[RateLimit("EndpointRateLimitPolicy")]
        public RemoteIp? Get(IPAddress? remoteIpAddress)
        {
            string? AddressFamily = HttpContext.Connection.RemoteIpAddress?.AddressFamily.ToString();
            string? ScopeId = string.Empty;
            string? IpAddress = string.Empty;


            if (HttpContext.Connection.RemoteIpAddress?.AddressFamily.ToString() == ProtocolFamily.InterNetworkV6.ToString())
            {
                ScopeId = HttpContext.Connection.RemoteIpAddress.ScopeId.ToString();
                IpAddress = HttpContext.Connection.RemoteIpAddress.MapToIPv6().ToString();
            }
            else
            {
                IpAddress = HttpContext.Connection.RemoteIpAddress?.MapToIPv4().ToString();
            }

            return new RemoteIp() { IpAddress = IpAddress, AddressFamily = AddressFamily, ScopeId = ScopeId };
        }
    }
}

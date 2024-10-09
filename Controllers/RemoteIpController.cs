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
            string? AddressFamily = string.Empty;
            string? ScopeId = string.Empty;
            string? IpAddress = string.Empty;

            if (HttpContext.Connection.RemoteIpAddress != null)
            {

                if (HttpContext.Connection.RemoteIpAddress.IsIPv4MappedToIPv6)
                {
                    IpAddress = HttpContext.Connection.RemoteIpAddress?.MapToIPv4().ToString();
                    AddressFamily = "IPv4";
                }
                else
                {
                    ScopeId = HttpContext.Connection.RemoteIpAddress.ScopeId.ToString();
                    IpAddress = HttpContext.Connection.RemoteIpAddress.MapToIPv6().ToString();
                    AddressFamily = "IPv6";
                }

                return new RemoteIp() { IpAddress = IpAddress, AddressFamily = AddressFamily, ScopeId = ScopeId };
            }
            else
            {
                return null;
            }

        }
    }
}

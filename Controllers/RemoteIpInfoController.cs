using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace IPService.Controllers;

[ApiController]
[Route("[controller]")]
public class RemoteIpInfoController : ControllerBase
{
    private readonly IpDatabaseService _ipDatabaseService;
    private readonly ILogger<RemoteIpController> _logger;

    public RemoteIpInfoController(ILogger<RemoteIpController> logger, IpDatabaseService ipDatabaseService)
    {
        _logger = logger;
        _ipDatabaseService = ipDatabaseService;
    }

    [HttpGet(Name = "GetRemoteIpAddressInfo")]
    //[RateLimit("EndpointRateLimitPolicy")]
    public RemoteIpInfo? Get(IPAddress? remoteIpAddress)
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

            _ipDatabaseService.GetIpInfo();

            return new RemoteIpInfo() { IpAddress = IpAddress, AddressFamily = AddressFamily, ScopeId = ScopeId };

            //, cityResponse = _ipDatabaseService.GetIpInfo()
        }
        else
        {
            return null;
        }

    }
}

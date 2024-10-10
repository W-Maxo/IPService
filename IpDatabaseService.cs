using AutoMapper;
using MaxMind.GeoIP2;
using System;
using System.IO;

namespace IPService;

public class IpDatabaseService
{
    DatabaseReader _reader;
    private readonly IMapper _mapper;

    public IpDatabaseService(IMapper mapper)
    {
        _mapper = mapper;
        _reader = new DatabaseReader(Path.Combine("database", "GeoLite2-City.mmdb"));
    }

    public RemoteIpInfo GetIpInfo(string? IpAddress)
    {
        if (!string.IsNullOrEmpty(IpAddress))
        {
            try
            {
                var ipInfo = _reader.City(IpAddress);

                return _mapper.Map<RemoteIpInfo>(ipInfo);
            }
            catch (Exception)
            {
                return new RemoteIpInfo();
            }
            
        }
        else
        {
            return new RemoteIpInfo();
        } 
    }
}


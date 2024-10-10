using AutoMapper;
using MaxMind.GeoIP2.Model;
using MaxMind.GeoIP2.Responses;

namespace IPService;

public class AppMappingProfile : Profile
{
    public AppMappingProfile()
    {
        CreateMap<CityResponse, RemoteIpInfo>();
        CreateMap<Traits, TraitsInfo>();
    }
}


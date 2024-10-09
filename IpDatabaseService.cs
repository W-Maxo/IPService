using MaxMind.GeoIP2;
using MaxMind.GeoIP2.Responses;
using System.IO;

namespace IPService;

public class IpDatabaseService
{
    DatabaseReader reader;

    public IpDatabaseService()
    {
        reader = new DatabaseReader(Path.Combine("database", "GeoLite2-City.mmdb")); ;
    }

    public string GetIpInfo()
    {
        var ipInfo = reader.City("178.125.89.228");


        return "";

    }
}

public class CityResponse
{
    public string City { get; set; }
    public Location Location { get; set; }
    public Postal Postal { get; set; }
    public List<string> Subdivisions { get; set; }
    public string Continent { get; set; }
    public string Country { get; set; }
    public string RegisteredCountry { get; set; }
    public string RepresentedCountry { get; set; }
    public Traits Traits { get; set; }
}

public class Location
{
    public string AccuracyRadius { get; set; }
    public string Latitude { get; set; }
    public string Longitude { get; set; }
    public string TimeZone { get; set; }
}

public class Postal
{
    public string Code { get; set; }
    public string Confidence { get; set; }
}

public class Root
{
    public CityResponse CityResponse { get; set; }
}

public class Traits
{
    public string AutonomousSystemNumber { get; set; }
    public string AutonomousSystemOrganization { get; set; }
    public string ConnectionType { get; set; }
    public string Domain { get; set; }
    public string IPAddress { get; set; }
    public string IsAnonymous { get; set; }
    public string IsAnonymousProxy { get; set; }
    public string IsAnonymousVpn { get; set; }
    public string IsAnycast { get; set; }
    public string IsHostingProvider { get; set; }
    public string IsLegitimateProxy { get; set; }
    public string IsPublicProxy { get; set; }
    public string IsResidentialProxy { get; set; }
    public string IsSatelliteProvider { get; set; }
    public string IsTorExitNode { get; set; }
    public string Isp { get; set; }
    public string MobileCountryCode { get; set; }
    public string MobileNetworkCode { get; set; }
    public string Network { get; set; }
    public string Organization { get; set; }
    public string StaticIPScore { get; set; }
    public string UserCount { get; set; }
    public string UserType { get; set; }
}


using MaxMind.GeoIP2.Model;

namespace IPService;

public class RemoteIpInfo : RemoteIp
{
    public string? City { get; set; }
    public Location? Location { get; set; }
    public Postal? Postal { get; set; }
    public List<string>? Subdivisions { get; set; }
    public string? Continent { get; set; }
    public string? Country { get; set; }
    public string? RegisteredCountry { get; set; }
    public string? RepresentedCountry { get; set; }
    public TraitsInfo? Traits { get; set; }
}

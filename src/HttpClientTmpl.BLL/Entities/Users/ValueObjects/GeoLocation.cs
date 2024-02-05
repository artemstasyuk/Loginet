namespace HttpClientTmpl.BLL.Entities.Users.ValueObjects;

public class GeoLocation
{
    public string Lat { get; set; }
    public string Lng { get; set; }
    
    public GeoLocation(string lat, string lng)
    {
        Lat = lat;
        Lng = lng;
    }
}
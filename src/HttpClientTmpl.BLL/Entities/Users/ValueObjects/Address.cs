namespace HttpClientTmpl.BLL.Entities.Users.ValueObjects;

public class Address
{
    public string Street { get; set; }
    public string Suite { get; set; }
    public string City { get; set; }
    
    public string Zipcode { get; set; }
    public GeoLocation Geo { get; set; }
    
    public Address(string street, string suite, string city, string zipcode, GeoLocation geo)
    {
        Street = street;
        Suite = suite;
        City = city;
        Zipcode = zipcode;
        Geo = geo;
    }
    
#pragma warning disable CS8618
    public Address(){}
}
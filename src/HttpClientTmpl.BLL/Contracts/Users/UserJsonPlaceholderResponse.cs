namespace HttpClientTmpl.BLL.Contracts.Users;

public record UserJsonPlaceholderResponse( 
    int Id, 
    string Name,
    string Username,
    string Email,
    AddressJsonPlaceholderResponse Address,
    string Phone,
    string Website,
    CompanyJsonPlaceholderResponse Company
);

public record AddressJsonPlaceholderResponse(
    string Street,
    string Suite,
    string City,
    string Zipcode,
    GeoLocationJsonPlaceholderResponse Geo
);

public record GeoLocationJsonPlaceholderResponse(
    string Lat,
    string Lng
);

public record CompanyJsonPlaceholderResponse(
    string Name,
    string CatchPhrase,
    string Bs
);
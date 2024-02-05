namespace HttpClientTmpl.BLL.Contracts.Users;

public record UserResponse( 
    int Id, 
    string? Name,
    string? Username,
    string? Email,
    AddressResponse Address,
    string? Phone,
    string? Website,
    CompanyResponse Company
);

public record AddressResponse(
    string? Street,
    string? Suite,
    string? City,
    string? Zipcode,
    GeoLocationResponse Geo
);

public record GeoLocationResponse(
    string? Lat,
    string? Lng
);

public record CompanyResponse(
    string? Name,
    string? CatchPhrase,
    string? Bs
);
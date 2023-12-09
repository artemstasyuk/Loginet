using Loginet.BLL.Contracts.Users;
using Loginet.BLL.Entities.Users;
using Loginet.BLL.Entities.Users.ValueObjects;

namespace Loginet.BLL.Mappers;

public static class UserMappers
{
    public static User ToUser(this UserJsonPlaceholderResponse user)
    {
        return new User(
            user.Id, 
            user.Name,
            user.Username, 
            user.Email, 
            new Address(
                user.Address.Street,
                user.Address.Suite, 
                user.Address.City,
                user.Address.Zipcode,
                new GeoLocation(
                    user.Address.Geo.Lat, 
                    user.Address.Geo.Lng)), 
            user.Phone, 
            user.Website, 
            new Company(
                user.Company.Name,
                user.Company.CatchPhrase,
                user.Company.Bs));
    }

    public static UserResponse ToUserResponse(this User user)
    {
        return new UserResponse( user.Id, 
            user.Name,
            user.Username, 
            user.Email, 
            new AddressResponse(
                user.Address.Street,
                user.Address.Suite, 
                user.Address.City,
                user.Address.Zipcode,
                new GeoLocationResponse(
                    user.Address.Geo.Lat, 
                    user.Address.Geo.Lng)), 
            user.Phone, 
            user.Website, 
            new CompanyResponse(
                user.Company.Name,
                user.Company.CatchPhrase,
                user.Company.Bs));
    }
    
    public static List<User> ToUsers(this IEnumerable<UserJsonPlaceholderResponse> users) =>
        users.Select(x => x.ToUser()).ToList();

    
    public static List<UserResponse> ToUserResponses(this IEnumerable<User> users) =>
        users.Select(x => x.ToUserResponse()).ToList();
}
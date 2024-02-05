using HttpClientTmpl.BLL.Entities.Users.Errors;
using HttpClientTmpl.BLL.Mappers;
using HttpClientTmpl.BLL.Entities.Users;
using HttpClientTmpl.BLL.Interfaces;
using HttpClientTmpl.BLL.Interfaces.Clients;
using HttpClientTmpl.BLL.Interfaces.Persistence;

namespace HttpClientTmpl.BLL.Services;

public class UserService : IUserService
{
    private readonly IJsonPlaceholderClient _jsonPlaceholderClient;

    private readonly IUserRepository _userRepository;

    public UserService(IJsonPlaceholderClient jsonPlaceholderClient, IUserRepository userRepository)
    {
        _jsonPlaceholderClient = jsonPlaceholderClient;
        _userRepository = userRepository;
    }

    public async Task<List<User>> GetUsersAsync()
    {
        if (await _userRepository.AnyAsync())
            return await _userRepository.ListAsync();


        if (await _jsonPlaceholderClient.GetUsersAsync() is not { } clientUsers) 
            throw new InvalidDataException();
        
        await _userRepository.AddRangeAsync(clientUsers.ToUsers());
        
        return await _userRepository.ListAsync();
    }
    
    public async Task<User> GetUserByIdAsync(int id)
    {
        if (await _userRepository.GetByIdAsync(id) is { } user)
            return user;
        
        if( await _jsonPlaceholderClient.GetUserByIdAsync(id) is not {} clientUser)
            throw new InvalidDataException();

        var newUser = clientUser.ToUser();
        await _userRepository.CreateAsync(newUser);
        
        return newUser;
    }
}

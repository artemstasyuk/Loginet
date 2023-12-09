using Loginet.BLL.Entities.Users;
using Loginet.BLL.Entities.Users.Errors;
using Loginet.BLL.Interfaces;
using Loginet.BLL.Interfaces.Clients;
using Loginet.BLL.Interfaces.Persistence;
using Loginet.BLL.Mappers;

namespace Loginet.BLL.Services;

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
        if (!await _userRepository.AnyAsync())
        {
           if( await _jsonPlaceholderClient.GetUsersAsync() is not {} clientUsers)
             throw new InvalidDataException();
           
           await _userRepository.AddRangeAsync(clientUsers.ToUsers());
        }
        var users = await _userRepository.ListAsync();
        return users;
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

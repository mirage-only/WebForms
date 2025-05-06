using WebForms.Application.DTOs;
using WebForms.Application.Mapping;
using WebForms.Core.Interfaces;
using WebForms.Core.Models;

namespace WebForms.Application.Services;

public class UsersService (IUsersRepository repository)
{
    public async Task<List<User>> GetAllUsers()
    {
        List<User> users = await repository.GetAllUsers();
        
        return users;
    }

    public async Task<User> Authorize(AuthorizeUserDto authorizeUserDto)
    {
        if (authorizeUserDto.Email == null)
        {
            throw new ArgumentNullException("Email can't be empty");
        }
        
        if (authorizeUserDto.PasswordHash == null)
        {
            throw new ArgumentNullException("PasswordHash can't be empty");
        }

        try
        {
            var user = await repository.Authorize(authorizeUserDto.Email, authorizeUserDto.PasswordHash);
            
            return user;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<ulong> AddUser(AddUserDto addUserDto)
    {
        try
        {
            var user = UsersMapping.MapAddUserDtoToUser(addUserDto);
            
            var email = addUserDto.Email;

            var alreadyRegisteredUser = await repository.GetUserByEmail(email);

            if (alreadyRegisteredUser != null)
            {
                throw new Exception("User with that email already registered");
            }
            
            var addedUserId = await repository.AddUser(user);

            return addedUserId;
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }
}
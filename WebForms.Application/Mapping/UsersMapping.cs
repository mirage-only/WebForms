using WebForms.Application.DTOs;
using WebForms.Core.Models;

namespace WebForms.Application.Mapping;

public class UsersMapping
{
    public static User? MapAddUserDtoToUser(AddUserDto addUserDto)
    {
        return new User()
        {
            Name = addUserDto.Name,

            Surname = addUserDto.Surname,

            Patronymic = addUserDto.Patronymic,

            Email = addUserDto.Email,

            PasswordHash = addUserDto.PasswordHash,
            
            Role = addUserDto.Role,
            
            Status = addUserDto.Status
        };
    }
}
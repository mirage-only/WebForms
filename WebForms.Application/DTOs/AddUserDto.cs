using WebForms.Core.Enums;

namespace WebForms.Application.DTOs;

public class AddUserDto
{
    public string Name { get; set; } = string.Empty;
    
    public string Surname { get; set; } = String.Empty;
    
    public string Patronymic { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;
    
    public string PasswordHash { get; set; } = string.Empty;
    
    public RoleEnum Role { get; set; } = RoleEnum.User;

    public StatusEnum Status { get; set; } = StatusEnum.Active;
}
namespace WebForms.Application.DTOs;

public class AuthorizeUserDto
{
    public string Email { get; set; }
    
    public string PasswordHash { get; set; }
}
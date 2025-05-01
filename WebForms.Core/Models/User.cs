using WebForms.Core.Enums;

namespace WebForms.Core.Models;

public class User
{
    public ulong Id {get; set;}
    
    public string Name {get; set;}
    
    public string Surname {get; set;}
    
    public string? Patronymic {get; set;}
    
    public string Email {get; set;}
    
    public string PasswordHash {get; set;}

    public RoleEnum Role { get; set; } = RoleEnum.User;
    
    public StatusEnum Status {get; set;} = StatusEnum.Active;
    
    public List<Template>? OwnTemplates {get; set;}
    
    public List<Form>? ReceivedAnswersForms {get; set;}
    
    public List<Form>? FilledForms {get; set;}
}
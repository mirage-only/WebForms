using WebForms.Core.Enums;
using WebForms.Core.Models;

namespace WebForms.Application.DTOs;

public class AddTemplateDto
{
    string Title { get; set; }

    public string Description { get; set; } = string.Empty;

    public TopicEnum Topic { get; set; } = TopicEnum.Another;

    public bool IsPrivate { get; set; } = false;
    
    public List<string> AccessHoldersEmails { get; set; } = new List<string>();
    
    public User Creator { get; set; }
}
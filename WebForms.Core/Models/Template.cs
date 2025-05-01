using WebForms.Core.Enums;

namespace WebForms.Core.Models;

public class Template
{
    public ulong Id { get; set; }
    
    public string Title { get; set; }
    
    public string? Description { get; set; }
    
    public TopicEnum Topic { get; set; }
    
    public List<Tag> Tags { get; set; }
    
    public string ImageLink { get; set; }
    
    public bool IsPrivate { get; set; } =  false;
    
    public List<string> AccessHoldersEmails { get; set; } = [];
    
    public User Creator { get; set; }
    
    public ulong CreatorId { get; set; }
    
    public List<string>? OneLineQuestions { get; set; }
    
    public List<string>? MultipleLineQuestions { get; set; }
    
    public List<string>? IntegersQuestions { get; set; }
    
    public List<SelectionQuestion>? SelectionQuestions { get; set; }
}
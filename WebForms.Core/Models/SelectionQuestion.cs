namespace WebForms.Core.Models;

public class SelectionQuestion
{
    public ulong Id { get; set; }
    
    public string Text { get; set; }

    public List<string> ResponseOptions { get; set; }
    
    public Template Template { get; set; }
    
    public ulong TemplateId { get; set; }
    
    public List<SelectionQuestionAnswer> Answers { get; set; }
}
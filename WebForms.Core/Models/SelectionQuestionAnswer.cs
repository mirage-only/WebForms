namespace WebForms.Core.Models;

public class SelectionQuestionAnswer
{
    public ulong Id { get; set; }
    
    public List<string> Answers { get; set; }
    
    public SelectionQuestion Question { get; set; }
    
    public ulong QuestionId { get; set; }
    
    public Form Form { get; set; }
    
    public ulong FormId { get; set; }
}
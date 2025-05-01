namespace WebForms.Core.Models;

public class Form
{
    public ulong Id { get; set; }

    public Template Template { get; set; }
    
    public ulong TemplateId { get; set; }
    
    public User FormOwner { get; set; }
    
    public ulong FormOwnerId { get; set; }
    
    public User FormFiller { get; set; }
    
    public ulong FormFillerId {get; set;}
    
    public List<string>? AnswersOneLine {get; set;}
    
    public List<string>? AnswersMultipleLine {get; set;}
    
    public List<uint>? AnswersNonNegativeIntegers { get; set; }

    public List<SelectionQuestionAnswer>? SelectionQuestionAnswers { get; set; }
}
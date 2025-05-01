namespace WebForms.Core.Models;

public class Tag
{
    public ulong Id { get; set; }
    
    public string TagName { get; set; }
    
    public List<Template> Templates {get; set;}
}
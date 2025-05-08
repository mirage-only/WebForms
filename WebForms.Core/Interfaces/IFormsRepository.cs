using WebForms.Core.Models;

namespace WebForms.Core.Interfaces;

public interface IFormsRepository
{
    public Task<List<Form>> GetAllForms();
    
    public Task<Form> GetFormById(ulong id);
    
    //public Task<ulong> AddForm(Form form);
}
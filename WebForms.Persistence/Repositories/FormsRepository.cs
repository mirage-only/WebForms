using Microsoft.EntityFrameworkCore;
using WebForms.Core.Interfaces;
using WebForms.Core.Models;

namespace WebForms.Persistence.Repositories;

public class FormsRepository(ApplicationDbContext dbContext): IFormsRepository
{
    public async Task<List<Form>> GetAllForms()
    {
        return await dbContext.Forms
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<Form> GetFormById(ulong id)
    {
        return await dbContext.Forms
            .AsNoTracking()
            .FirstOrDefaultAsync(form => form.Id == id) ?? throw new Exception("Form not found"); 
    }
}
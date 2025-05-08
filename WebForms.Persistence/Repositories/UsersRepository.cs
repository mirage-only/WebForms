using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using WebForms.Core.Interfaces;
using WebForms.Core.Models;

namespace WebForms.Persistence.Repositories;

public class UsersRepository(ApplicationDbContext dbContext) : IUsersRepository
{
    public async Task<List<User>> GetAllUsers()
    {
        return await dbContext.Users
            .AsNoTracking()
            .OrderBy(user => user.Surname)
            .ToListAsync();
    }
    
    public async Task<User?> GetUserByEmail(string email)
    {
        return await dbContext.Users
            .AsNoTracking()
            .FirstOrDefaultAsync(user => user.Email == email);
    }

    public async Task<User> Authorize(string email, string passwordHash)
    {
        var user = dbContext.Users
            .AsNoTracking()
            .FirstOrDefaultAsync(user => user.Email == email && user.PasswordHash == passwordHash);

        return await user ?? throw new Exception("User not found");
    }

    public async Task<ulong> AddUser(User user)
    {
        try
        {
            var addedUser = await dbContext.Users
                .AddAsync(user);
            
            await dbContext.SaveChangesAsync();
            
            return addedUser.Entity.Id;
        }
        catch (Exception e)
        {
            throw new Exception("An error occured while adding user", e);
        }
    }

    /*public async Task<List<User>> GetWithAllFormsAndTemplates()
    {
        return await dbContext.Users
            .AsNoTracking()
            .Include(user => user.OwnTemplates)
            .Include(user => user.FilledForms)
            .Include(user => user.ReceivedAnswersForms)
            .ToListAsync();
    }*/
}
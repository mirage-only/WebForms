using WebForms.Core.Models;

namespace WebForms.Core.Interfaces;

public interface IUsersRepository
{
    public Task<List<User>> GetAllUsers();
    
    public Task<User> GetUserByEmail(string id);
    
    public Task<ulong> AddUser(User user);
    
    //удаление юзера

    public Task<User> Authorize(string email, string passwordHash);
}
using Microsoft.EntityFrameworkCore;
using UserTestingAPI.Application.Utilities;
using UserTestingAPI.Core.Repository;
using UserTestingAPI.Domain.Entities;

namespace UserTestingAPI.Application.Services;

public class UserManager
{
    private readonly IRepository _repository;

    public UserManager(IRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<User>> GetUsers()
    {
        return await _repository.GetAll<User>().ToListAsync(); 
    }
    
    public async Task<User?> FindByEmailAsync(string email)
    {
        var user =
            await (from u in _repository.GetAll<User>() 
                    where u.Email == email 
                    select u
                    ).AsNoTracking()
                    .FirstOrDefaultAsync();
        if (user == null)
        {
            throw new Exception("Wrong email");
        }
        return user;
    } 
    
    public async Task<User?> FindByIdAsync(Guid id)
    {
        var user = await (from u in _repository.GetAll<User>()
            where u.Id == id
            select u).AsNoTracking().FirstOrDefaultAsync();
        if (user == null)
        {
            throw new Exception("User not found by email");
        }
        return user;
    }
    
    public Task<bool> CheckPasswordAsync(User user, string password)
    {
        var hashedPassword = PasswordUtility.GetHashedPassword(password, user.PasswordSalt);
        return Task.FromResult(hashedPassword == user.PasswordHash);
    }
    
    public async Task DeleteUser(Guid id)
    {
        var user = await FindByIdAsync(id);
        _repository.Delete(user);
        await _repository.SaveChangesAsync();
    }
}
using Microsoft.EntityFrameworkCore;
using UserTestingAPI.Domain.Entities;

namespace UserTestingAPI.Database;

public class UserTestingDbContext : DbContext
{
    public UserTestingDbContext(DbContextOptions<UserTestingDbContext> options) : base(options)
    {
        
    }
    
    public DbSet<User> User { get; set; }
}
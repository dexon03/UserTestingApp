using Microsoft.EntityFrameworkCore;
using UserTestingAPI.Database.Seed;
using UserTestingAPI.Domain.Entities;

namespace UserTestingAPI.Database;

public class UserTestingDbContext : DbContext
{
    public UserTestingDbContext(DbContextOptions<UserTestingDbContext> options) : base(options)
    {
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var user = DbSeed.GetSeedUser();
        var tests = DbSeed.GetSeedTest();
        var completedTests = DbSeed.GetSeedAsssignedAndCompletedTest(user, tests);
        var questions = DbSeed.GetSeedQuestions(tests);
        var options = DbSeed.GetSeedOptions(questions);
        modelBuilder.Entity<User>().HasData(user);
        modelBuilder.Entity<Question>().HasData(questions);
        modelBuilder.Entity<Option>().HasData(options);
        modelBuilder.Entity<Test>().HasData(tests);
        modelBuilder.Entity<UserTests>().HasData(completedTests);
    }

    public DbSet<User> User { get; set; }
    public DbSet<Test> Test { get; set; }
    public DbSet<Question> Question { get; set; }
    public DbSet<Option> Option { get; set; }
    public DbSet<UserTests> UserTests { get; set; }
}
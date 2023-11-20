using UserTestingAPI.Core.Repository;

namespace UserTestingAPI.Database.Repository;

public class Repository : BaseRepository, IRepository
{
    public Repository(UserTestingDbContext context, ILogger<Repository> logger) : base(context, logger)
    {
        
    }
}
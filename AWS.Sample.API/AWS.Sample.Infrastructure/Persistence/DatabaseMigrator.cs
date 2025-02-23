using Microsoft.EntityFrameworkCore;

namespace AWS.Sample.Infrastructure.Persistence;

public class DatabaseMigrator
{
    private readonly AWSDbContext _context;

    public DatabaseMigrator(AWSDbContext context)
    {
        _context = context;
    }
    
    public void Migrate()
    {
        if (_context.Database.GetPendingMigrations().Any())
        {
            _context.Database.Migrate();
        }
    }
}
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace AWS.Sample.Infrastructure.Persistence;

public class AWSDbContextFactory : IDesignTimeDbContextFactory<AWSDbContext>
{
    public AWSDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<AWSDbContext>();
        optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=aws-sample;Username=sa;Password=sa234;");

        return new AWSDbContext(optionsBuilder.Options);
    }
}
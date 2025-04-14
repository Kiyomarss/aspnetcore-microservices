using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Ordering.Infrastructure.Data;

namespace Ordering.Infrastructure;

public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
{
    public ApplicationDbContext CreateDbContext(string[] args)
    {
        var configuration = new ConfigurationBuilder()
                            .SetBasePath(Directory.GetCurrentDirectory()) // مسیر ریشه پروژه
                            .AddJsonFile("appsettings.json", optional: false)
                            .Build();

        var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
        var connectionString = configuration.GetConnectionString("Database");

        optionsBuilder.UseSqlServer(connectionString); // یا UseNpgsql یا UseSqlite، بسته به دیتابیس

        return new ApplicationDbContext(optionsBuilder.Options);
    }
}
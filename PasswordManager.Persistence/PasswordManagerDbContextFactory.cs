using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace PasswordManager.Persistence;

public class PasswordManagerDbContextFactory : IDesignTimeDbContextFactory<PasswordManagerDbContext>
{
    public PasswordManagerDbContext CreateDbContext(string[] args)
    {
        var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Development";
        var basePath = Path.Combine(Directory.GetCurrentDirectory(), "../PasswordManager.Api");

        var configuration = new ConfigurationBuilder()
              .SetBasePath(basePath)
              .AddJsonFile("appsettings.json")
              .AddJsonFile($"appsettings.{environment}.json", optional: true)
              .Build();

        var optionsBuilder = new DbContextOptionsBuilder<PasswordManagerDbContext>();
        optionsBuilder.UseNpgsql(configuration.GetConnectionString("Postgres"));

        return new PasswordManagerDbContext(optionsBuilder.Options);
    }
}

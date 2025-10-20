using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace PasswordManager.Persistence;

public static class PersistenceServiceCollection
{
    public static IServiceCollection AddPersistenceServiceCollection(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<PasswordManagerDbContext>(options =>
        {
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnectionString"),
                m => m.MigrationsAssembly("PasswordManager.Api"));
        });

        return services;
    }
}

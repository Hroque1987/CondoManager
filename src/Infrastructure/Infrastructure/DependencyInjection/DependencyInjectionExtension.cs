using Owners.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Infrastructure.Persistance;
using Infrastructure.Respositories;


namespace Infrastructure.DependencyInjection;

public static class DependencyInjectionExtension
{
    public static IServiceCollection AddOwnersInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        AddDbContext(services, configuration);

        AddOwnerRepositories(services);

        return services;
    }

    private static void AddOwnerRepositories(IServiceCollection services)
    {
        services.AddScoped<IOwnerRepository, OwnerRespository>();
    }

    public static void AddDbContext(IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<OwnerDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        });
    }
}

using Microsoft.Extensions.DependencyInjection;
using Owners.Application.Queries.GetOwnerById;
using Owners.Application.Queries.GetOwners;

namespace Owners.Application;

public static class DependencyInjectionExtension
{
    public static IServiceCollection AddOwnersApplication(this IServiceCollection services)
    {


        AddHandlers(services);

        return services;
    }



    private static void AddHandlers(IServiceCollection services)
    {
        services.AddScoped<IGetOwners, GetOwners>();
        services.AddScoped<IGetOwnerById, GetOwnerById>();
    }
}

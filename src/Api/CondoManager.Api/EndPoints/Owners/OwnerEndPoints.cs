using API.HttpMapping;
using Owners.Application.Queries.GetOwners;

namespace API.EndPoints.Owners;

public static class OwnerEndPoints
{
    public static IEndpointRouteBuilder MapOwnerEndPoints( this IEndpointRouteBuilder app)
    {
        app.MapGet("/owners", async (GetOwnersQueryService handler) =>
        {
            return (await handler.GetOwners()).MapToHttp(); 
            
        } );
            

        return app;
    }
}
  


using API.HttpMapping;
using Microsoft.AspNetCore.Mvc;
using Owners.Application.Queries.GetOwnerById;
using Owners.Application.Queries.GetOwners;
using Owners.Contracts.Responses;

namespace API.EndPoints.Owners;

public static class OwnerEndPoints
{
    public static IEndpointRouteBuilder MapOwnerEndPoints( this IEndpointRouteBuilder app)
    {
        app.MapGet("/owners", async (IGetOwners handler) =>
        {
            return (await handler.Execute()).MapToHttp(); 
            
        }).Produces<List<OwnerResponse>>(StatusCodes.Status200OK);

        app.MapGet("/owner/{id}", async (Guid id, IGetOwnerById handler) => 
        { 
            
            return (await handler.Execute(id)).MapToHttp();
        }).Produces<OwnerResponse>(StatusCodes.Status200OK);
            

        return app;
    }
}
  


using Owners.Contracts.Responses;
using Owners.Domain.Entities;

namespace Owners.Application.Mappings;

public static class OwnerMappings
{
    public static OwnerResponse ToResponse(this Owner owner)
    {
        var response = new OwnerResponse(
                        owner.Id,
                        owner.Name.FirstName,
                        owner.Name.LastName,
                        owner.Email.Value,
                        owner.Status.ToString()
                        );

        return response;
    }
  
    
}

using Owners.Application.ApplicationErrors;
using Owners.Application.Interfaces;
using Owners.Application.Mappings;
using Owners.Contracts.Responses;
using SharedKernel.Result;

namespace Owners.Application.Queries.GetOwnerById;

public sealed class GetOwnerById : IGetOwnerById
{
    private readonly IOwnerRepository _ownerRepository;

    public GetOwnerById(IOwnerRepository ownerRepository)
    {
        _ownerRepository = ownerRepository;
    }

    public async Task<Result<OwnerResponse>> Execute(Guid ownerId)
    {
        var owner = await _ownerRepository.GetByIdAsync(ownerId);

        if(owner == null) 
            return GeneralErrors.NotFound;
        
        return OwnerMappings.ToResponse(owner);

    }

}

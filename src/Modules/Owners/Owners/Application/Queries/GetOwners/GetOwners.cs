using SharedKernel.Result;
using Owners.Application.Mappings;
using Owners.Contracts.Responses;
using Owners.Application.Interfaces;

namespace Owners.Application.Queries.GetOwners;

public sealed class GetOwners : IGetOwners
    
{
    private readonly IOwnerRepository _ownerRepository;

    public GetOwners(IOwnerRepository ownerRepository)
    {
        _ownerRepository = ownerRepository;
    }

    public async Task<Result<List<OwnerResponse>>> Execute()
    {
        var owners = await _ownerRepository.GetAllAsync();
        var result = owners.Select(owner => OwnerMappings.ToResponse(owner)).ToList();

        return Result<List<OwnerResponse>>.Success(result);
    }
}

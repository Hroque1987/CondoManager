using SharedKernel.Result;
using Owners.Application.Mappings;
using Owners.Contracts.Responses;
using Owners.Application.Interfaces;

namespace Owners.Application.Queries.GetOwners;

public sealed class GetOwnersQueryService
    
{
    private readonly IOwnerRepository _repo;

    public GetOwnersQueryService(IOwnerRepository repo)
    {
        _repo = repo;
    }

    public async Task<Result<List<OwnerResponse>>> GetOwners()
    {
        var owners = await _repo.GetAllAsync();
        var result = owners.Select(owner => OwnerMappings.ToResponse(owner)).ToList();

        return Result<List<OwnerResponse>>.Success(result);
    }
}

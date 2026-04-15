using Owners.Contracts.Responses;
using SharedKernel.Result;

namespace Owners.Application.Queries.GetOwners;

public interface IGetOwners
{
    Task<Result<List<OwnerResponse>>> Execute();
}

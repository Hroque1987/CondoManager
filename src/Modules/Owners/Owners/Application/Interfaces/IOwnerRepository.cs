using Owners.Domain.Entities;

namespace Owners.Application.Interfaces;

public interface IOwnerRepository
{
    Task<IReadOnlyList<Owner>> GetAllAsync();

    Task<Owner?> GetByIdAsync(Guid id);
}

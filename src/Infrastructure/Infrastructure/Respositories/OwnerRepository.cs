using Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;
using Owners.Application.Interfaces;
using Owners.Domain.Entities;

namespace Infrastructure.Respositories;

public class OwnerRepository(OwnerDbContext ownerDbContext) : IOwnerRepository
{
    private readonly OwnerDbContext _ownerContext = ownerDbContext;

    public async Task<IReadOnlyList<Owner>> GetAllAsync()
    => await _ownerContext.Set<Owner>()
        .AsNoTracking()
        .ToListAsync();

    public async Task<Owner?> GetByIdAsync(Guid id)
        => await _ownerContext.Owners.FindAsync(id).AsTask();
}

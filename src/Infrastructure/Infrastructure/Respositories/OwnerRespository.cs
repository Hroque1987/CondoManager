using Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;
using Owners.Application.Interfaces;
using Owners.Domain.Entities;

namespace Infrastructure.Respositories;

public class OwnerRespository(OwnerDbContext ownerDbContext) : IOwnerRepository
{
    private readonly OwnerDbContext _ownerContext = ownerDbContext;

    public async Task<IReadOnlyList<Owner>> GetAllAsync() => await _ownerContext.Set<Owner>().ToListAsync();
   
}

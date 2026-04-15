namespace Owners.Contracts.Responses;

public sealed record OwnerResponse(
    Guid Id,
    string FirstName,
    string LastName,
    string Email,
    string Status
);
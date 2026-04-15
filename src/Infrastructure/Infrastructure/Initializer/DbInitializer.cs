using Infrastructure.Persistance;
using Owners.Domain.Entities;
using Owners.Domain.ValueObjects;

namespace Infrastructure.Initializer;

public class DbInitializer
{
    public static async Task SeedData(OwnerDbContext ownerContext)
    {
        if (ownerContext.Owners.Any()) 
            return;

        var owners = new List<Owner>
        {
            CreateValidOwner("Jane", "Doe", "jane.doe@mail.com"),
            CreateValidOwner("John", "Doe", "john.doe@mail.com"),
            CreateValidOwner("Matthew", "Scott", "matthew.scott@mail.com"),
            CreateValidOwner("Jennifer", "Scott", "jennifer.scott@mail.com"),
            CreateValidOwner("Peter", "White", "peter.white@mail.com"),
            CreateValidOwner("Miguel", "Doe", "miguel.doe@mail.com"),
            CreateValidOwner("Laura", "Silva", "laura.silva@mail.com"),
            CreateValidOwner("Carlos", "Pereira", "carlos.pereira@mail.com"),
            CreateValidOwner("Ana", "Costa", "ana.costa@mail.com"),
            CreateValidOwner("David", "Smith", "david.smith@mail.com")
        };

        ownerContext.Owners.AddRange(owners);

        await ownerContext.SaveChangesAsync();
 
    }


    private static Owner CreateValidOwner(string firstname, string lastName, string mail)
    {
        var fullName = FullName.Create(firstname, lastName).Value;
        var email = Email.Create(mail).Value;

        return Owner.Create(fullName, email).Value;
    }
}

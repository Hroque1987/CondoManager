using Owners.Domain.Entities;
using Owners.Domain.Errors;
using Owners.Domain.ValueObjects;

namespace UnitTests.Owners;

public class OwnerTests
{
    [Fact]
    public void Should_Create_Owner_Successfully()
    {
        var fullNameResult = FullName.Create("John", "Doe");
        var emailResult = Email.Create("valid.email@gmail.com");

        Assert.True(fullNameResult.IsSuccess);
        Assert.True(emailResult.IsSuccess);

        var ownerResult = Owner.Create(fullNameResult.Value, emailResult.Value);

        Assert.True(ownerResult.IsSuccess);
        Assert.False(ownerResult.IsFailure);
        Assert.NotNull(ownerResult.Value);
        Assert.Equal(fullNameResult.Value.ToString(), ownerResult.Value.Name.ToString());
    }

    [Fact]
    public void Should_Fail_When_Creating_Owner_With_Empty_FullName()
    {
        var fullNameResult = FullName.Create("", "");
        var emailResult = Email.Create("valid.email@gmail.com");

        Assert.True(fullNameResult.IsFailure);
        Assert.True(emailResult.IsSuccess);

        var ownerResult = Owner.Create(default!, emailResult.Value);

        Assert.True(ownerResult.IsFailure);
        Assert.Equal(OwnerErrors.OwnerFullNameEmpty, ownerResult.Errors[0]);
    }

    [Fact]
    public void Should_Fail_When_Creating_Owner_With_Empty_Email()
    {
        var fullNameResult = FullName.Create("John", "Doe");
        var emailResult = Email.Create("");

        Assert.True(fullNameResult.IsSuccess);
        Assert.True(emailResult.IsFailure);

        var ownerResult = Owner.Create(fullNameResult.Value, default!);

        Assert.True(ownerResult.IsFailure);
        Assert.Equal(OwnerErrors.OwnerEmailEmpty, ownerResult.Errors[0]);
    }

    [Fact]
    public void Should_Change_Email_Successfully()
    {
        var owner = CreateValidOwner();

        var newEmailResult = Email.Create("new.email@gmail.com");
        Assert.True(newEmailResult.IsSuccess);

        var result = owner.ChangeEmail(newEmailResult.Value);

        Assert.True(result.IsSuccess);
    }

    [Fact]
    public void Should_Fail_When_Changing_Email_On_Inactive()
    {
        var owner = CreateValidOwner();
        owner.Inactivate();

        var emailResult = Email.Create("new.email@gmail.com");
        
        Assert.True(emailResult.IsSuccess);

        var result = owner.ChangeEmail(emailResult.Value);

        Assert.True(result.IsFailure);
        Assert.Equal(OwnerErrors.Inactive, result.Errors[0]);
    }

    [Fact]
    public void Should_Inactivate_Owner_Successfully()
    {
        var owner = CreateValidOwner();

        var result = owner.Inactivate();

        Assert.True(result.IsSuccess);
    }

    [Fact]
    public void Should_Fail_When_Inactivating_Already_Inactive_Owner()
    {
        var owner = CreateValidOwner();

        owner.Inactivate();

        var result = owner.Inactivate();

        Assert.True(result.IsFailure);
        Assert.Equal(OwnerErrors.AlreadyInactive, result.Errors[0]);
    }

    [Fact]
    public void Should_Activate_Inactive_Owner_Successfully()
    {
        var owner = CreateValidOwner();

        owner.Inactivate();

        var result = owner.Activate();

        Assert.True(result.IsSuccess);
    }

    [Fact]
    public void Should_Fail_When_Activating_Already_Active_Owner()
    {
        var owner = CreateValidOwner();

        var result = owner.Activate();

        Assert.True(result.IsFailure);
        Assert.Equal(OwnerErrors.AlreadyActive, result.Errors[0]);
    }

   
    // Helpers
   

    private static Owner CreateValidOwner()
    {
        var fullName = FullName.Create("John", "Doe").Value;
        var email = Email.Create("valid.email@gmail.com").Value;

        return Owner.Create(fullName, email).Value;
    }
}
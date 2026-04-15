using Owners.Domain.Errors;
using Owners.Domain.ValueObjects;

namespace UnitTests.Owners;

public class FullNameTests
{
    [Fact]
    public void Should_Create_FullName_Successfully()
    {
        var firstName = "John";
        var lastName = "Doe";

        var result = FullName.Create(firstName, lastName);

        Assert.True(result.IsSuccess);
        Assert.False(result.IsFailure);
        Assert.NotNull(result.Value);
        Assert.Equal($"{firstName} {lastName}", result.Value.ToString());
    }

    [Fact]
    public void Should_Fail_When_FirstName_Is_Empty()
    {
        var result = FullName.Create("", "Doe");

        Assert.True(result.IsFailure);
        Assert.Equal(FullNameErrors.FirstNameEmpty, result.Errors[0]);
    }

    [Fact]
    public void Should_Fail_When_LastName_Is_Empty()
    {
        var result = FullName.Create("John", "");

        Assert.True(result.IsFailure);
        Assert.Equal(FullNameErrors.LastNameEmpty, result.Errors[0]);
    }

    [Fact]
    public void Should_Fail_When_FirstName_Exceeds_Max_Length()
    {
        var longFirstName = new string('A', 101);

        var result = FullName.Create(longFirstName, "Doe");

        Assert.True(result.IsFailure);
        Assert.Equal(FullNameErrors.FirstNameTooLong, result.Errors[0]);
    }

    [Fact]
    public void Should_Fail_When_LastName_Exceeds_Max_Length()
    {
        var longLastName = new string('B', 101);

        var result = FullName.Create("John", longLastName);

        Assert.True(result.IsFailure);
        Assert.Equal(FullNameErrors.LastNameTooLong, result.Errors[0]);
    }
}
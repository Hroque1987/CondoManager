using Owners.Domain.Errors;
using Owners.Domain.ValueObjects;

namespace UnitTests.Owners;

public class EmailTests
{
    [Fact]
    public void Should_Create_Email_Successfully()
    {
        var mail = "valid.email@gmail.com";

        var result = Email.Create(mail);

        Assert.True(result.IsSuccess);
        Assert.False(result.IsFailure);
        Assert.NotNull(result.Value);
        Assert.Equal(mail.ToLowerInvariant(), result.Value.Value);
    }

    [Fact]
    public void Should_Fail_When_Email_Is_Empty()
    {
        var result = Email.Create("");

        Assert.True(result.IsFailure);
        Assert.Equal(EmailErrors.Empty, result.Errors[0]);
    }

    [Theory]
    [InlineData("invalid.email")]
    [InlineData("@gmail.com")]
    [InlineData("invalid.email@")]
    public void Should_Fail_When_Email_Has_Invalid_Format(string mail)
    {
        var result = Email.Create(mail);

        Assert.True(result.IsFailure);
        Assert.Equal(EmailErrors.InvalidFormat, result.Errors[0]);
    }
}
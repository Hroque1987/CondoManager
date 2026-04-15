using SharedKernel.Result;

namespace Owners.Domain.Errors;

public static class EmailErrors
{
    public static readonly Error Empty =
        Error.Domain("EMAIL_EMPTY", "Email cannot be empty");

    public static readonly Error InvalidFormat =
        Error.Domain("EMAIL_INVALID", "Email format is invalid");
}

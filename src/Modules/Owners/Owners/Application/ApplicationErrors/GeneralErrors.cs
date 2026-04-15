using SharedKernel.Result;

namespace Owners.Application.ApplicationErrors;

public static class GeneralErrors
{
    public static readonly Error NotFound =
        Error.NotFound("NOT_FOUND", "Resource not found");

}

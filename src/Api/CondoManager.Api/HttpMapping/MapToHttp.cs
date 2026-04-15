using SharedKernel.Result;

namespace API.HttpMapping;

public static class ResultExtensions
{
    public static IResult MapToHttp<T>(this Result<T> result)
    {
        if (result.IsSuccess)
            return Results.Ok(result.Value);

        var error = result.Errors.First();

        return error.Type switch
        {
            ErrorType.Validation => ToValidation(error),
            ErrorType.NotFound => ToProblem(error, StatusCodes.Status404NotFound),
            ErrorType.Conflict => ToProblem(error, StatusCodes.Status409Conflict),
            _ => ToProblem(error, StatusCodes.Status500InternalServerError)
        };
    }

    private static IResult ToProblem(Error error, int status)
    {
        var extensions = error.Details is null
            ? []
            : error.Details.ToDictionary(
                x => x.Key,
                x => (object?)x.Value);

        return Results.Problem(
            title: error.Code,
            detail: error.Message,
            statusCode: status,
            extensions: extensions);
    }

    private static IResult ToValidation(Error error)
    {
        return Results.ValidationProblem(
            error.Details ?? [],
            title: error.Message);
    }
}

using Microsoft.AspNetCore.Mvc;

namespace API.Configuration;

public static class StatusCodePagesConfiguration
{
    public static WebApplication AddStatusCodePages(this WebApplication app)
    {
        app.UseStatusCodePages();
        app.UseStatusCodePages(async context =>
        {
            var response = context.HttpContext.Response;

            if (response.ContentType?.Contains("problem") == true)
                return;

            var problem = new ProblemDetails
            {
                Status = response.StatusCode,
                Title = "Request error",
                Detail = "A problem occurred while processing the request."
            };

            response.ContentType = "application/problem+json";

            await response.WriteAsJsonAsync(problem);
        });


        return app;
    }
}

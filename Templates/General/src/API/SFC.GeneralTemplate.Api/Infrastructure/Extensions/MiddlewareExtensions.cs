using SFC.GeneralTemplate.Api.Infrastructure.Middlewares;

namespace SFC.GeneralTemplate.Api.Infrastructure.Extensions;

public static class MiddlewareExtensions
{
    public static IApplicationBuilder UseCustomExceptionHandler(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<ExceptionHandlerMiddleware>();
    }
}

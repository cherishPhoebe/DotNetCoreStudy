using MarkdownFormatMiddlewareDemo.Middlewares;

namespace Microsoft.AspNetCore.Builder
{
    public static class MarkdownFormatMiddlewareExtensions
    {

        public static IApplicationBuilder UseMarkdownFormat(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<MarkdownFormatMiddleware>();
        }

    }
}

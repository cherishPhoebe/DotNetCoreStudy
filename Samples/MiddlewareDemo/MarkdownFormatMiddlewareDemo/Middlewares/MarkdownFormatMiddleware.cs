using MarkdownSharp;
using Microsoft.Extensions.Caching.Memory;
using System.Text;
using Ude;

namespace MarkdownFormatMiddlewareDemo.Middlewares
{
    public class MarkdownFormatMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IWebHostEnvironment _environment;
        private readonly IMemoryCache _memoryCache;

        public MarkdownFormatMiddleware(RequestDelegate next, IWebHostEnvironment environment, IMemoryCache memoryCache)
        {
            _next = next;
            _environment = environment;
            _memoryCache = memoryCache;
        }

        public async Task Invoke(HttpContext context)
        {
            var path = context.Request.Path.Value ?? "";
            if (!path.ToLower().EndsWith(".md")) { 
                await _next(context);
                return;
            }

            var file = _environment.WebRootFileProvider.GetFileInfo(path);
            if (!file.Exists)
            {
                await _next(context);
                return;
            }

            context.Response.ContentType = "text/html;charset=UTF-8";
            context.Response.StatusCode = 200;

            string cacheKey = nameof(MarkdownFormatMiddleware) + path + file.LastModified;
            var html = await _memoryCache.GetOrCreateAsync(cacheKey, async ce => {
                ce.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(20);
                using (var stream = file.CreateReadStream()) {
                    var text = await ReadText(stream);
                    Markdown markdown = new Markdown();
                    return markdown.Transform(text);
                }
            });

            await context.Response.WriteAsync(html);
        }

        private async Task<string> ReadText(Stream stream)
        {
            string charset = DetectCharset(stream);
            using var reader = new StreamReader(stream, Encoding.GetEncoding(charset));
            return await reader.ReadToEndAsync();
        }

        private string DetectCharset(Stream stream)
        {
            CharsetDetector charDetector = new();
            charDetector.Feed(stream);
            charDetector.DataEnd();
            string charset = charDetector.Charset ?? "UTF-8";
            stream.Position = 0;
            return charset;
        }
    }

}

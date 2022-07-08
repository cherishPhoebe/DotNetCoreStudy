using Microsoft.AspNetCore.Mvc.Filters;

namespace ExceptionFilterDemo.Filter
{
    public class LogExceptionFilter : IAsyncExceptionFilter
    {
        private readonly ILogger<SampleExceptionFilter> _logger;

        public LogExceptionFilter(ILogger<SampleExceptionFilter> logger)
        {
            _logger = logger;
        }

        public Task OnExceptionAsync(ExceptionContext context)
        {
            _logger.LogError(context.Exception, context.Exception.Message.ToString());
            return Task.CompletedTask;
        }
    }
}

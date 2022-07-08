using Microsoft.AspNetCore.Mvc.Filters;

namespace ExceptionFilterDemo.Filter
{
    public class SampleExceptionFilter : IAsyncExceptionFilter
    {
        private readonly IHostEnvironment _hostEnvironment;
        private readonly ILogger<SampleExceptionFilter> _logger;

        public SampleExceptionFilter(IHostEnvironment hostEnvironment, ILogger<SampleExceptionFilter> logger)
        {
            _hostEnvironment = hostEnvironment;
            _logger = logger;
        }

        public Task OnExceptionAsync(ExceptionContext context)
        {
            if (_hostEnvironment.IsDevelopment()) {

            }
            _logger.LogError(context.Exception, context.Exception.Message.ToString());
            context.ExceptionHandled = true;
            return Task.CompletedTask;
        }
    }
}

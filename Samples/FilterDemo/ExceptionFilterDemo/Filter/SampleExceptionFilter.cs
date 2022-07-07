using Microsoft.AspNetCore.Mvc.Filters;

namespace ExceptionFilterDemo.Filter
{
    public class SampleExceptionFilter : IAsyncExceptionFilter
    {
        private readonly IHostEnvironment _hostEnvironment;

        public SampleExceptionFilter(IHostEnvironment hostEnvironment)
        {
            _hostEnvironment = hostEnvironment;
        }

        public Task OnExceptionAsync(ExceptionContext context)
        {
            return Task.CompletedTask;
        }
    }
}

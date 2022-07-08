using Microsoft.AspNetCore.Mvc;
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
            var result = new ObjectResult(new { code = 500, message = "服务器异常" });
            if (_hostEnvironment.IsDevelopment())
            {
                result = new ObjectResult(new { code = 500, message = context.Exception.Message });
            }
            context.Result = result;
            context.ExceptionHandled = true;
            return Task.CompletedTask;
        }
    }
}

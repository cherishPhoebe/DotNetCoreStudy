using ActionFilterDemo.Attributes;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ActionFilterDemo.Filters
{
    public class SampleActionFilter : IAsyncActionFilter
    {
        private ILogger<SampleActionFilter> _logger;

        public SampleActionFilter(ILogger<SampleActionFilter> logger)
        {
            _logger = logger;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            // action 方法执行前执行的代码
            var isNoLog = false;
            if (context.ActionDescriptor is ControllerActionDescriptor) {
                var controllerActionDescriptor = context.ActionDescriptor as ControllerActionDescriptor;
                isNoLog = controllerActionDescriptor.MethodInfo.IsDefined(typeof(NoLogAttribute),true);
            }
            if (isNoLog)
            {
                await next();
                return;
            }

            // action 方法执行后执行的代码

        }
    }
}

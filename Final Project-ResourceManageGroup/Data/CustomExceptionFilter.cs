using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
namespace ResourceManageGroup.Data
{
public class CustomExceptionFilter : Attribute ,IExceptionFilter
{
    private readonly ILogger<CustomExceptionFilter> _logger;

    public CustomExceptionFilter(ILogger<CustomExceptionFilter> logger)
    {
        _logger = logger;
    }

    public void OnException(ExceptionContext context)
    {
        _logger.LogError(context.Exception, "An exception occurred.");
        context.Result = new RedirectToActionResult("HandleErrorCode", "Error", new { statusCode = 500 });
        context.ExceptionHandled = true;
    }
}
}
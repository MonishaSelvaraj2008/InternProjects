using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ActionFilters.Data
{
    public class CustomActionFilter : TypeFilterAttribute, IActionFilter
    {
        public CustomActionFilter() : base(typeof(CustomActionFilter))
        {
        }
        
        public void OnActionExecuting(ActionExecutingContext context)
        {
            watch = Stopwatch.StartNew();
        }
        Stopwatch watch;


        public void OnActionExecuted(ActionExecutedContext context)
        {
            var watch = Stopwatch.StartNew();


            watch.Stop();
            context.HttpContext.Response.WriteAsync("Action Execution Time is " + watch.ElapsedTicks.ToString());
        }
    }
}
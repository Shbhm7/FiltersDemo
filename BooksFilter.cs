using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;

public class BooksFilter : IActionFilter
{
    private readonly ILogger<BooksFilter> _logger;
    public BooksFilter(ILogger<BooksFilter> logger)
    {
        _logger = logger;
    }
    
    public void OnActionExecuting(ActionExecutingContext context)
    {
        _logger.LogInformation("Action is executing...");
        if (!context.ModelState.IsValid)
        {
         context.Result = new BadRequestObjectResult(context.ModelState);
        }
    }

    public void OnActionExecuted(ActionExecutedContext context)
    {
        _logger.LogInformation("Action has executed.");
        if (context.Result is ObjectResult objectResult)
        {
          var data = objectResult.Value;
        }
   }
}

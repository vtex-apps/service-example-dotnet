using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Refit;

namespace DotNetService.Utils
{
    // Makes so ApiExceptions change the ActionResult of the response context according to their own status code.
    // Refit by default throws an ApiException on all 40X or 50X status codes.
    public class RefitExceptionHandler : ExceptionFilterAttribute
    {
        public override Task OnExceptionAsync(ExceptionContext context)
        {
            context.Result = context.Exception switch
            {
                ApiException ex => new StatusCodeResult((int) ex.StatusCode),
                // Unhandled exceptions are still thrown
                { } ex => throw ex
            };
            return Task.CompletedTask;
        }
    }
}
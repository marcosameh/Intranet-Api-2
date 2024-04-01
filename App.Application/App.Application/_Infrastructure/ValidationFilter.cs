using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Linq;

namespace App.Application._Infrastructure
{
    public class ValidationFilter : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (!context.ModelState.IsValid)
            {
                var error = context.ModelState.Where(x => x.Value.Errors.Count > 0)
                    .ToDictionary(kvp => kvp.Key, kvp => kvp.Value.Errors.Select(e => e.ErrorMessage))
                    .FirstOrDefault();

                var operationResult = new OperationResult
                {
                    IsSuccess = false,
                    Code = "1",
                    Message = error.Value.FirstOrDefault()
                };

                context.Result = new BadRequestObjectResult(operationResult);
                return;
            }
            await next();
        }
    }
}

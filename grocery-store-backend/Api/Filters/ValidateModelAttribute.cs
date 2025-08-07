using Microsoft.AspNetCore.Mvc.Filters;
using Exceptions = grocery_store_backend.Config.Exceptions;
namespace grocery_store_backend.Api.Filters;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = true, AllowMultiple = false)]
public class ValidateModelAttribute() : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        if (context.ModelState.IsValid) return;
        var errors = context.ModelState
            .Values
            .SelectMany(v => v.Errors)
            .Select(e => e.ErrorMessage);

        string details = string.Join("; ", errors);
        throw new Exceptions.ValidationException(details);
    }
}

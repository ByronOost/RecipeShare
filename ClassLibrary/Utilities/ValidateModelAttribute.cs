using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace ClassLibrary.Utilities
{
    public class ValidateModelAttribute : ActionFilterAttribute
    {
        private readonly ILogger<ValidateModelAttribute> _logger;

        public ValidateModelAttribute(ILogger<ValidateModelAttribute> logger)
        {
            _logger = logger;
        }

        // This function is used in place of
        // if(!ModelState.IsValid) { }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                var controllerName = context.Controller.GetType().Name;
                var actionName = context.ActionDescriptor.DisplayName;

                _logger.LogWarning("Model validation failed for action: {ActionName} in controller: {ControllerName}.",
                    actionName,
                    controllerName);

                foreach (var modelState in context.ModelState)
                {
                    if (modelState.Value.Errors.Any())
                    {
                        var fieldName = modelState.Key;
                        var attemptedValue = modelState.Value.RawValue;
                        var errorMessages = string.Join(", ", modelState.Value.Errors.Select(e => e.ErrorMessage));

                        _logger.LogError("Validation error in field: {FieldName}. Attempted value: {AttemptedValue}. Errors: {Errors}. " +
                            "Action: {ActionName}, Controller: {ControllerName}",
                            fieldName,
                            attemptedValue ?? "null",
                            errorMessages,
                            actionName,
                            controllerName);
                    }
                }

                context.Result = new BadRequestResult();
            }
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace RecipeShare.Helpers
{
    public static class ApiResponseHelper
    {
        public static IActionResult OkResponse(string? message = null, object? data = null)
        {
            var response = new ApiResponse
            {
                Status = "success",
                Message = message ?? "Operation successful",
                Data = data ?? new object[0]
            };

            return new OkObjectResult(response);
        }

        public static IActionResult CreatedResponse(string? message = null, object? data = null)
        {
            var response = new ApiResponse
            {
                Status = "success",
                Message = message ?? "Resource created successfully",
                Data = data ?? new object[0]  // Return an empty array when data is null
            };

            return new CreatedResult("", response);
        }

        public static IActionResult BadRequestResponse(string? message = null, ModelStateDictionary? modelState = null)
        {
            var response = new ApiResponse
            {
                Status = "error",
                Message = message ?? "Bad request",
            };

            if (modelState != null && modelState.ErrorCount > 0)
            {
                response.Errors = modelState.Keys
                .SelectMany(key => modelState[key].Errors.Select(error => error.ErrorMessage))
                .ToArray();
            }

            return new BadRequestObjectResult(response);
        }

        public static IActionResult BadRequestResponse(string? message = null)
        {
            var response = new ApiResponse
            {
                Status = "error",
                Message = message ?? "Bad request",
            };

            return new BadRequestObjectResult(response);
        }


        public static IActionResult NotFoundResponse(string message = "Resource not found")
        {
            var response = new ApiResponse
            {
                Status = "error",
                Message = message,
            };

            return new NotFoundObjectResult(response);
        }

        public static IActionResult InternalServerErrorResponse(string message = "An error occurred")
        {
            var response = new ApiResponse
            {
                Status = "error",
                Message = message,
            };

            return new ObjectResult(response)
            {
                StatusCode = StatusCodes.Status500InternalServerError
            };
        }
    }

    public class ApiResponse
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
        public string[] Errors { get; set; }
    }
}

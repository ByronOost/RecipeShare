using ClassLibrary.Utilities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Logging;
using Moq;

namespace RecipeShare.Tests.Utilities
{
    public class ValidateModelAttributeTests
    {
        private readonly Mock<ILogger<ValidateModelAttribute>> _mockLogger;
        private readonly ValidateModelAttribute _filter;

        public ValidateModelAttributeTests()
        {
            _mockLogger = new Mock<ILogger<ValidateModelAttribute>>();
            _filter = new ValidateModelAttribute(_mockLogger.Object);
        }

        [Fact]
        public void OnActionExecuting_InvalidModelState_SetsBadRequestResult()
        {
            var modelState = new Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary();
            modelState.AddModelError("Name", "Required");

            var actionContext = new ActionContext(
                new DefaultHttpContext(),
                new RouteData(),
                new Microsoft.AspNetCore.Mvc.Abstractions.ActionDescriptor(),
                modelState);

            var actionExecutingContext = new ActionExecutingContext(
                actionContext,
                new List<IFilterMetadata>(),
                new Dictionary<string, object?>(),
                controller: new object());

            _filter.OnActionExecuting(actionExecutingContext);

            Assert.IsType<BadRequestResult>(actionExecutingContext.Result);

            _mockLogger.Verify(
                logger => logger.Log(
                    LogLevel.Warning,
                    It.IsAny<EventId>(),
                    It.Is<It.IsAnyType>((v, t) => v.ToString()!.Contains("Model validation failed")),
                    It.IsAny<Exception?>(),
                    It.IsAny<Func<It.IsAnyType, Exception?, string>>()),
                Times.Once);

            _mockLogger.Verify(
                logger => logger.Log(
                    LogLevel.Error,
                    It.IsAny<EventId>(),
                    It.Is<It.IsAnyType>((v, t) => v.ToString()!.Contains("Validation error in field")),
                    It.IsAny<Exception?>(),
                    It.IsAny<Func<It.IsAnyType, Exception?, string>>()),
                Times.Once);
        }

        [Fact]
        public void OnActionExecuting_ValidModelState_DoesNotSetResult()
        {
            var modelState = new Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary();

            var actionContext = new ActionContext(
                new DefaultHttpContext(),
                new RouteData(),
                new Microsoft.AspNetCore.Mvc.Abstractions.ActionDescriptor(),
                modelState);

            var actionExecutingContext = new ActionExecutingContext(
                actionContext,
                new List<IFilterMetadata>(),
                new Dictionary<string, object?>(),
                controller: new object());

            _filter.OnActionExecuting(actionExecutingContext);

            Assert.Null(actionExecutingContext.Result);

            _mockLogger.Verify(
                logger => logger.Log(
                    It.Is<LogLevel>(l => l == LogLevel.Warning || l == LogLevel.Error),
                    It.IsAny<EventId>(),
                    It.IsAny<It.IsAnyType>(),
                    It.IsAny<Exception?>(),
                    It.IsAny<Func<It.IsAnyType, Exception?, string>>()),
                Times.Never);
        }
    }
}

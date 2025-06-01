using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace RecipeShare.Middleware
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _requestDelegate;
        private readonly IServiceProvider _serviceProvider;

        public ExceptionHandlingMiddleware(
            RequestDelegate requestDelegate,
            ILogger<ExceptionHandlingMiddleware> logger,
            IServiceProvider serviceProvider)
        {
            _requestDelegate = requestDelegate ?? throw new ArgumentNullException(nameof(requestDelegate));
            _serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _requestDelegate(context);
            }
            catch (Exception ex)
            {
                if (!context.Response.HasStarted)
                {
                    await ReturnInternalServerErrorResponse(context);
                }
            }

            // Only attempt to handle status codes if the response hasn't started
            if (!context.Response.HasStarted)
            {
                if (context.Response.StatusCode == StatusCodes.Status400BadRequest)
                {
                    await ReturnBadRequestResponse(context);
                }

                if (context.Response.StatusCode == StatusCodes.Status404NotFound)
                {
                    await ReturnNotFoundResponse(context);
                }

                if (context.Response.StatusCode == StatusCodes.Status500InternalServerError)
                {
                    await ReturnInternalServerErrorResponse(context);
                }
            }
        }

        private Task ReturnBadRequestResponse(HttpContext context)
        {
            context.Response.StatusCode = StatusCodes.Status400BadRequest;

            return RenderViewAsync(context, "Errors/BadRequest", "400");
        }

        private Task ReturnNotFoundResponse(HttpContext context)
        {
            context.Response.StatusCode = StatusCodes.Status404NotFound;

            return RenderViewAsync(context, "Errors/NotFound", "404");
        }

        private Task ReturnInternalServerErrorResponse(HttpContext context)
        {
            context.Response.StatusCode = StatusCodes.Status500InternalServerError;

            return RenderViewAsync(context, "Errors/InternalServer", "500");
        }

        private async Task RenderViewAsync(HttpContext context, string viewName, string errorCode)
        {
            try
            {
                // Resolve view-related services
                var viewEngine = _serviceProvider.GetRequiredService<ICompositeViewEngine>();
                var tempDataProvider = _serviceProvider.GetRequiredService<ITempDataProvider>();
                var urlHelperFactory = _serviceProvider.GetRequiredService<IUrlHelperFactory>();

                // Prepare the action context and view data
                var routeData = new RouteData();
                routeData.Routers.Add(new RouteCollection());
                var actionContext = new ActionContext(context, routeData, new ActionDescriptor());

                var viewData = new ViewDataDictionary(new EmptyModelMetadataProvider(), new ModelStateDictionary());

                var tempData = new TempDataDictionary(context, tempDataProvider);

                // Render the view to a string
                using (var writer = new StringWriter())
                {
                    var viewResult = viewEngine.FindView(actionContext, viewName, false);

                    if (viewResult.Success)
                    {
                        var viewContext = new ViewContext(
                            actionContext,
                            viewResult.View,
                            viewData,
                            tempData,
                            writer,
                            new HtmlHelperOptions()
                        );

                        await viewResult.View.RenderAsync(viewContext);
                        var htmlOutput = writer.ToString();

                        context.Response.ContentType = "text/html";
                        await context.Response.WriteAsync(htmlOutput);
                    }
                    else
                    {
                        context.Response.ContentType = "text/plain";
                        await context.Response.WriteAsync($"View '{viewName}' not found.");
                    }
                }
            }
            catch (Exception ex)
            {
                context.Response.ContentType = "text/plain";
                await context.Response.WriteAsync("An error occurred while processing your request.");
            }
        }
    }
}

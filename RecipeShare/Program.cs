using ClassLibrary.Data;
using ClassLibrary.Repositories;
using ClassLibrary.Repositories.Interfaces;
using ClassLibrary.Utilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using RecipeShare.Middleware;
using System.Text.Json.Serialization;

try
{
    var builder = WebApplication.CreateBuilder(args);

    // HttpClient for external API calls (if needed)
    var baseAddress = builder.Environment.IsDevelopment()
        ? "https://localhost:7069/api/"
        : "http://localhost:7069/api/";

    builder.Services.AddHttpClient("RecipeApi", client =>
    {
        client.BaseAddress = new Uri(baseAddress);
    });

    // Add controllers with views (API + MVC) + JSON options to ignore cycles
    builder.Services.AddControllersWithViews()
        .AddJsonOptions(options =>
        {
            options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
        });

    // Add Razor Pages if you have any
    builder.Services.AddRazorPages();

    // Swagger setup for API documentation
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen(options =>
    {
        options.SwaggerDoc("v1", new OpenApiInfo { Title = "RecipeShare API", Version = "v1" });

        options.SupportNonNullableReferenceTypes();

        options.CustomSchemaIds(type => type.FullName);
    });

    // Register your DbContext with connection string
    builder.Services.AddDbContext<ApplicationDbContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

    // Automapper registration
    builder.Services.AddAutoMapper(typeof(Program).Assembly);

    builder.Services.AddScoped<ValidateModelAttribute>(); 
    builder.Services.AddScoped<IRecipeRepository, RecipeRepository>();
    builder.Services.AddScoped<DietaryTagRepository>();

    var app = builder.Build();

    // Apply migrations on startup
    using (var scope = app.Services.CreateScope())
    {
        var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        db.Database.Migrate();
    }

    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();

    app.UseStaticFiles();

    app.UseRouting();

    app.UseAuthentication();
    app.UseAuthorization();

    app.UseMiddleware<ExceptionHandlingMiddleware>();

    // API area routing
    app.MapAreaControllerRoute(
        name: "api",
        areaName: "Api",
        pattern: "api/{controller=Home}/{action=Index}/{id?}");

    // Default MVC route
    app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");

    app.MapRazorPages();

    app.Run();
}
catch (Exception ex)
{
    Console.WriteLine(ex);
    throw;
}

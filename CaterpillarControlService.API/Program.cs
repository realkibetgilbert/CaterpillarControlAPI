using CaterpillarControlService.API.Core.Models;
using CaterpillarControlService.API.Extensions;
using CaterpillarControlService.API.Infrastructure.ApplicationDbContext;
using CaterpillarControlService.API.Infrastructure.SeedData;
using CaterpillarControlService.API.Middleware;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.ConfigureSerilog();
// Add services to the container.
builder.Services.AddApplicationServices(builder.Configuration, builder.Environment);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllers().AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);
builder.Services.AddSwaggerDocumentation();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<CustomExceptionHandlerMiddleware>();

app.UseHttpsRedirection();


app.MapControllers();

using var scope = app.Services.CreateScope();

var services = scope.ServiceProvider;

var loggerFactory = services.GetRequiredService<ILoggerFactory>();


app.UseApplicationServices(builder.Configuration, builder.Environment);


try
{
    var roleManager = services.GetRequiredService<RoleManager<IdentityRole<long>>>();

    var userManager = services.GetRequiredService<UserManager<User>>();


    using (var serviceScope = services.GetRequiredService<IServiceScopeFactory>().CreateScope())
    {
        var context = serviceScope.ServiceProvider.GetService<CaterpillarDbContext>();
        context.Database.Migrate();
    }


    await CaterpillarControlSeeder.SeedRolesAsync(roleManager, loggerFactory);

    await CaterpillarControlSeeder.SeedRiderAsync(userManager, loggerFactory, roleManager, builder.Configuration);
}
catch (Exception ex)
{

    var logger = loggerFactory.CreateLogger<Program>();

    logger.LogError(ex, "An error occurred during migration");
}


app.Run();

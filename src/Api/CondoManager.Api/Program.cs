using API.Configuration;
using API.EndPoints.Owners;
using Infrastructure.DependencyInjection;
using Infrastructure.Initializer;
using Infrastructure.Persistance;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Owners.Application;
using Scalar.AspNetCore;


var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.AddLogging();

builder.Services.AddOpenApi();

builder.Services.AddOwnersInfrastructure(builder.Configuration);
builder.Services.AddOwnersApplication();


builder.Services.AddProblemDetails();

var app = builder.Build();

app.AddStatusCodePages();

app.MapOwnerEndPoints();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{

    app.MapOpenApi();
    app.MapScalarApiReference();
}

using var scope = app.Services.CreateScope();

var services = scope.ServiceProvider;

try
{
    var context = services.GetRequiredService<OwnerDbContext>();
    await context.Database.MigrateAsync();

    if(app.Environment.IsDevelopment())
        await DbInitializer.SeedData(context);
    
}catch(Exception ex) { 
    var logger = services.GetRequiredService<ILogger<Program>>();
    logger.LogError(ex, "An error ocurred during migration");
    throw;
}

app.Run();

//using DotNetEnv;
using Ecommerce.Infrastructure.Legacy;
using Microsoft.EntityFrameworkCore;
using System;
using Npgsql;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
// Add services
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddDbContext<AddDbContext>(options =>
//    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
// load .env file
//Env.Load(Path.Combine(Directory.GetCurrentDirectory(), ".env"));

//Console.WriteLine(Directory.GetCurrentDirectory());

//// build connection string từ env
//var host = Environment.GetEnvironmentVariable("DB_HOST");
//var port = Environment.GetEnvironmentVariable("DB_PORT");
//var dbName = Environment.GetEnvironmentVariable("DB_NAME");
//var user = Environment.GetEnvironmentVariable("DB_USER");
//var pass = Environment.GetEnvironmentVariable("DB_PASSWORD")?.Trim();

//Console.WriteLine($"Host: {host}");
//Console.WriteLine($"DB: {dbName}");
//Console.WriteLine($"User: {user}");
//Console.WriteLine($"Password: {pass}");

//var connString =
//    $"Host={host};Port={port};Database={dbName};Username={user};Password={pass};SSL Mode=Require;Trust Server Certificate=true";

//try
//{
//    await using var conn = new NpgsqlConnection(connString);

//    await conn.OpenAsync();

//    Console.WriteLine("CONNECTED SUCCESS");
//}
//catch (Exception ex)
//{
//    Console.WriteLine(ex.ToString());
//}

builder.Services.AddDbContext<StoreDbContext>(options =>
    options.UseNpgsql(
        builder.Configuration.GetConnectionString("DefaultConnection")));

var connString = builder.Configuration.GetConnectionString("DefaultConnection");

Console.WriteLine(connString);

var app = builder.Build();

//using var scope = app.Services.CreateScope();

//var db = scope.ServiceProvider.GetRequiredService<StoreDbContext>();
//Console.WriteLine($"Database Connected: {db.Database.CanConnect()}");

//Console.WriteLine($"Products Count: {db.Hanghoas.Count()}");
// Middleware
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Test endpoint
app.MapGet("/weatherforecast", () =>
{
var summaries = new[]
{
        "Freezing", "Bracing", "Chilly", "Cool", "Mild",
        "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

var forecast = Enumerable.Range(1, 5).Select(index =>
    new WeatherForecast(
        DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
        Random.Shared.Next(-20, 55),
        summaries[Random.Shared.Next(summaries.Length)]
    )
).ToArray();

return forecast;
});

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}

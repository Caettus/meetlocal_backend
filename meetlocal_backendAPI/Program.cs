using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using MLDAL; // Add this line to import the AppDbContext class
using Microsoft.EntityFrameworkCore;
using System.Configuration;
using backend.application.Repositories;
using backend.application.Services;

var builder = WebApplication.CreateBuilder(args);

// Load your app settings and configuration
var configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json")
    .Build();


// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<gatheringService, gatheringService>();
builder.Services.AddScoped<gatheringRepository, gatheringRepository>();

// Configure CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("VueAppCorsPolicy", builder =>
    {
        builder
            .WithOrigins("http://localhost:8080") // Replace with the actual URL of your Vue.js project
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

// Register the configuration
builder.Services.AddSingleton<IConfiguration>(configuration);

// Add the following line to register the AppDbContext service
builder.Services.AddDbContext<AppDbContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("ConnectionString")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();

// Use CORS
app.UseCors("VueAppCorsPolicy");

app.MapControllers();
app.Run();

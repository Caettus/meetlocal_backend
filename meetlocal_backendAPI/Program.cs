using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using System.IO;

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

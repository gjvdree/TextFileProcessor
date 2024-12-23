using TextFileProcessor.Application.Extensions;
using TextFileProcessor.Persistance.Extensions;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// For testing, log to console
builder.Logging.ClearProviders();
builder.Logging.AddConsole();

// TODO: add Logging i.e. Serilog 

// TODO: Authentication

// Add services to the container.
builder.Services.AddControllers();

// Add services
builder.Services.AddApplicationServices(); //Calls extension method for application
builder.Services.AddPersistanceServices(); //Calls extension method for persistance

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
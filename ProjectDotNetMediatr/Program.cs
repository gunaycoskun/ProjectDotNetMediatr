using Mediator.Net;
using Mediator.Net.MicrosoftDependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// Create and configure mediator
var mediaBuilder = new MediatorBuilder();
var mediator = mediaBuilder.RegisterHandlers(typeof(Program).Assembly).Build();
builder.Services.AddScoped<IMediator>(sp => mediator);
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
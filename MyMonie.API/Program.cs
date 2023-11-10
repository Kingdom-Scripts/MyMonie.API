
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using MyMonie.API;
using MyMonie.Core.Middlewares;
using MyMonie.Core.Models.App;
using Serilog;
using System.Configuration;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateBootstrapLogger();

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddScoped<IValidator<UserModel>, UserModelValidator>();
builder.Services.AddControllers();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<MyMonieContext>(options =>
{
    var df = builder.Configuration.GetConnectionString("MyMonie");
    options.UseSqlServer(builder.Configuration.GetConnectionString("MyMonie"));
    options.LogTo(Console.WriteLine, LogLevel.Information);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{

}

app.UseSwagger();
    app.UseSwaggerUI();

app.UseMiddleware<ErrorHandlerMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
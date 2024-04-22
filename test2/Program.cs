using System;
using test2.Data;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using test2.Services;
using WebAPI.Services;
using Serilog;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var _logger = new LoggerConfiguration()
 .WriteTo.Console()
 .WriteTo.File("Logs/Book_log.txt", rollingInterval: RollingInterval.Minute)
 .MinimumLevel.Information()
 .CreateLogger();
builder.Logging.ClearProviders();

builder.Logging.AddSerilog(_logger);
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<ICoursesServices, CoursesServices>();
builder.Services.AddDbContext<test2Dbcontext>(options =>options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

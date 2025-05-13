using HRM.API.Filters.ActionFilters;
using HRM.API.Filters.ExceptionFilters;
using HRM.API.Middlewares;
using HRM.Application.DependencyInjection;
using HRM.Infrastructure.DependencyInjection;
using HRM.Persistence.DependencyInjection;
using Microsoft.OpenApi.Models;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((context, services, configuration) =>
{
    configuration
        .ReadFrom.Configuration(context.Configuration)
        .ReadFrom.Services(services)
        .Enrich.FromLogContext()
        .WriteTo.Console()
        .WriteTo.File("Logs/log.txt", rollingInterval: RollingInterval.Day);
});

// Add services
builder.Services.AddControllers();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
    });
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "HRM API", Version = "v1" });
});

builder.Services.AddScoped<LoggingActionFilter>();
builder.Services.AddScoped<ExecutionTimeFilter>();
builder.Services.AddScoped<GlobalExceptionFilter>();

builder.Services.AddControllers(options =>
{
    // Đăng ký filter toàn cục nếu muốn áp dụng mọi nơi
    options.Filters.Add<LoggingActionFilter>();
    options.Filters.Add<ExecutionTimeFilter>();
    // options.Filters.Add<GlobalExceptionFilter>();
});

builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddPersistence(builder.Configuration);
builder.Services.AddApplication();

var app = builder.Build();

// Đặt Exception Middleware ở đầu tiên
app.UseMiddleware<ExceptionHandlingMiddleware>();

// Các middleware khác
app.UseSwagger();
app.UseSwaggerUI();

app.UseCors("AllowAll");
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();


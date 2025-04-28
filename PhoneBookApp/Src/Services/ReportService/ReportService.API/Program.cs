using FluentValidation.AspNetCore;
using FluentValidation;
using Microsoft.OpenApi.Models;
using ReportService.Application.DependencyInjection;
using ReportService.Infrastructure.DependecyInjection;
using ReportService.Application.Features.Handlers;
using ReportService.Application.Validators;
using ReportService.API.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// 1️⃣ Application Katmanı DI Registrations
builder.Services.AddApplicationServices();

// 2️⃣ Infrastructure Katmanı DI Registrations
builder.Services.AddInfrastructureServices(builder.Configuration);

// 3️⃣ FluentValidation Ayarları
builder.Services.AddValidatorsFromAssemblyContaining<CreateReportCommandValidator>();
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddFluentValidationClientsideAdapters();

// 4️⃣ MediatR Ayarları
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CreateReportCommandHandler).Assembly));

// 5️⃣ Swagger Ayarları
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Report Microservice API", Version = "v1" });
});

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Report Microservice API V1");
        c.RoutePrefix = string.Empty; // Swagger ana sayfa olsun
    });
}
app.UseMiddleware<ExceptionMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

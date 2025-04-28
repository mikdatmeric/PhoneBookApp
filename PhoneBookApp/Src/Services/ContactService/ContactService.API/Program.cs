using ContactService.API.Middlewares;
using ContactService.Application.DependencyInjection;
using ContactService.Application.Features.PersonFeatures.Handlers;
using ContactService.Application.Mappings;
using ContactService.Application.Validators.PersonValidators;
using ContactService.Infrastructure.DependencyInjection;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddAutoMapper(typeof(MappingProfile).Assembly);

// 1️⃣ Application Katmanı DI Registrations
builder.Services.AddApplicationServices();

// 2️⃣ Infrastructure Katmanı DI Registrations
builder.Services.AddInfrastructureServices(builder.Configuration);

// 3️⃣ FluentValidation Ayarları
builder.Services.AddValidatorsFromAssemblyContaining<CreatePersonCommandValidator>();
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddFluentValidationClientsideAdapters();

// 4️⃣ MediatR Ayarları
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CreatePersonCommandHandler).Assembly));

// 5️⃣ Swagger Ayarları
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Contact Microservice API", Version = "v1" });
});

// 6️⃣ Controller Ayarları
builder.Services.AddControllers();

// 7️⃣ CORS Ayarları (İstersen ekleyebiliriz)
// builder.Services.AddCors(...);

var app = builder.Build();

// 8️⃣ Development Ortamı İçin Swagger UI Açalım
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Contact Microservice API V1");
        c.RoutePrefix = string.Empty; // Swagger ana sayfa olsun
    });
}

app.UseMiddleware<ExceptionMiddleware>();

// 9️⃣ HTTPS Redirection (Opsiyonel)
app.UseHttpsRedirection();

// 🔟 Authorization (İstersen buraya koyabiliriz ileride Auth eklerken)
// app.UseAuthentication();
// app.UseAuthorization();

app.MapControllers();

app.Run();
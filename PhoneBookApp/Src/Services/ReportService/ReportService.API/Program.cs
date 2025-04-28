using Microsoft.EntityFrameworkCore;
using ReportService.Infrastructure.DependecyInjection;
using ReportService.Infrastructure.Persistence.Contexts;

var builder = WebApplication.CreateBuilder(args);

// 🔥 Buraya ConnectionString ve DbContext ayarını ekliyoruz:
builder.Services.AddDbContext<ReportDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddInfrastructureServices(builder.Configuration);



// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

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

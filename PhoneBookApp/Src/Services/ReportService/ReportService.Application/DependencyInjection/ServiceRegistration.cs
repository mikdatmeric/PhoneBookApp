using Microsoft.Extensions.DependencyInjection;
using ReportService.Application.Services.Abstract;
using ReportService.Application.Services.Concrete;

namespace ReportService.Application.DependencyInjection
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IReportService, ReportManager>();

            return services;
        }
    }
}

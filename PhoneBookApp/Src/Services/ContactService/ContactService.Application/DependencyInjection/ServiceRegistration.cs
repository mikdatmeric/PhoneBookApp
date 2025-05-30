﻿using ContactService.Application.Services.Abstract;
using ContactService.Application.Services.Concrete;
using Microsoft.Extensions.DependencyInjection;

namespace ContactService.Application.DependencyInjection
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IPersonService, PersonManager>();
            services.AddScoped<IContactInfoService, ContactInfoManager>();
            services.AddScoped<ICountryService, CountryManager>();

            return services;
        }
    }
}

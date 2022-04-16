using Application.Interfaces;
using Application.Services;
using Domain.Dtos;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<Api>(configuration.GetSection("Api"));
            services.AddTransient<IBillServices, BillServices>();
            services.AddTransient<IApiServices, ApiServices>();
            return services;
        }

    }
}

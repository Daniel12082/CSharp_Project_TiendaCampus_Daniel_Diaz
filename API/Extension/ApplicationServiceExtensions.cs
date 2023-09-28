using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Interface;
using Infrastructure.UnitOfWork;

namespace API.Extension;

    public static class ApplicationServiceExtensions
    {
        public static void ConfigureCors(this IServiceCollection services)=>
        services.AddCors(options =>
        {
            options.AddPolicy("CorsPolicy", builder =>
            {
                builder.AllowAnyHeader() //WithOrigins("https://localhost:4200")
                .AllowAnyMethod()   //WithMethods("GET", "POST", "PUT", "DELETE")
                .WithOrigins("https://localhost:4200"); //WithHeaders("accept", "content-type", "origin", "x-custom-header");
            });
        });
        public static void AddAplicationServices(this IServiceCollection services)
        {
            services.AddScoped<UnitOfWork>();
        }
    }

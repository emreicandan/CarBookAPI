using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using CarBook.Application.Pipelines.Validation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace CarBook.Application.DependencyResolver;

    public static class ServiceRegistration
    {
        public static void AddApplicationServices(this IServiceCollection services){
            
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddMediatR(configuration =>
        {
            configuration.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly());
        });
        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));
        }
    }

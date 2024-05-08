using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarBook.Application.Repository.Services;
using CarBook.Persistence.Context;
using CarBook.Persistence.Repository.Concretes;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace CarBook.Persistence.DependencyResolver;

    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services){
            
            services.AddDbContext<CarBookDbContext>();
            services.AddScoped<IBrandRepository,BrandRepository>();
            services.AddScoped<ICarRepository,CarRepository>();
            services.AddScoped<ICarFeatureRepository,CarFeatureRepository>();
            services.AddScoped<ICategoryRepository,CategoryRepository>();
            services.AddScoped<ICarPaymentRepository,CarPaymentRepository>();
            services.AddScoped<IFeatureRepository,FeatureRepository>();
            services.AddScoped<IPaymentRepository,PaymentRepository>();
            services.AddScoped<IContactRepository,ContactRepository>();
            services.AddScoped<IUserRepository , UserRepository>();
            services.AddScoped<IRoleRepository , RoleRepository>();
        }
    }

using FluentValidation;
using GestionZapatillas.Data;
using GestionZapatillas.Entities;
using GestionZapatillas.Repositories;
using GestionZapatillas.Repositories.Interfaces;
using GestionZapatillas.Services.Interfaces;
using GestionZapatillas.Services.Services;
using GestionZapatillas.Validators;
using Microsoft.Extensions.DependencyInjection;

namespace GestionZapatillas.IoC
{
    public static class DependencyInjectionContainer
    {
        public static IServiceProvider Configure()
        {
            var services = new ServiceCollection();
            services.AddApplicationServices();
            return services.BuildServiceProvider();
        }

        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddDbContext<ShoeDbContext>();
            services.AddScoped<IBrandRepository, BrandRepository>();
            services.AddScoped<ISportRepository, SportRepository>();
            services.AddScoped<ISizeRepository, SizeRepository>();
            services.AddScoped<IGenreRepository, GenreRepository>();
            services.AddScoped<ISportShoeRepository, SportShoeRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IBrandService, BrandService>();
            services.AddScoped<ISportService, SportService>();
            services.AddScoped<ISizeService, SizeService>();
            services.AddScoped<IGenreService, GenreService>();
            services.AddScoped<ISportShoeService, SportShoeService>();
            services.AddScoped<IValidator<Brand>, BrandValidator>();
            services.AddScoped<IValidator<Sport>, SportValidator>();
            services.AddScoped<IValidator<Size>, SizeValidator>();
            services.AddScoped<IValidator<SportShoe>, SportShoeValidator>();
            return services;
        }
    }
}

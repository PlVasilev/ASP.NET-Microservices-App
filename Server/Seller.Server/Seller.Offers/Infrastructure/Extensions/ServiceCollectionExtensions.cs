﻿namespace Seller.Offers.Infrastructure.Extensions
{
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.OpenApi.Models;
    using Features.Services;
    using Features.Services.Interfaces;
    using Filters;

    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddAppServices(this IServiceCollection services) => services
            .AddTransient<IOfferService, OfferService>();



        public static IServiceCollection AddSwagger(this IServiceCollection services) => services
            .AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo() {Title = "Seller API", Version = "v1"});
            });

        public static void AddApiControllers(this IServiceCollection services) =>
            services.AddControllers(option => option.Filters.Add<ModelOrNotFoundActionFilter>());

    }
}

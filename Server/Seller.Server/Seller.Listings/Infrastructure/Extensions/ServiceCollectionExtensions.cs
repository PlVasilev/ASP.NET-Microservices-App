using Seller.Listings.Features.Seller.Services;
using Seller.Listings.Features.Seller.Services.Interfaces;
using Seller.Listings.Infrastructure.Filters;

namespace Seller.Listings.Infrastructure.Extensions
{
    using Features.Listing.Services;
    using Features.Listing.Services.Interfaces;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.OpenApi.Models;

    public static class ServiceCollectionExtensions
    {
        //public static AppSettings GetAppSettings(this IServiceCollection services, IConfiguration configuration)
        //{
        //    var appSettingsSection = configuration.GetSection("AppSettings");
        //    services.Configure<AppSettings>(appSettingsSection);
        //    return appSettingsSection.Get<AppSettings>();
        //}

        //public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration) => services
        //    .AddDbContext<ListingsDbContext>(options => options.UseSqlServer(configuration.GetDeaultConnectionString()));


        //public static IServiceCollection AddJwtAuthentication(this IServiceCollection services, AppSettings appSettings)
        //{
        //    var key = Encoding.ASCII.GetBytes(appSettings.Secret);

        //    services.AddAuthentication(x =>
        //        {
        //            x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        //            x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        //        })
        //        .AddJwtBearer(x =>
        //        {
        //            x.RequireHttpsMetadata = false;
        //            x.SaveToken = true;
        //            x.TokenValidationParameters = new TokenValidationParameters
        //            {
        //                ValidateIssuerSigningKey = true,
        //                IssuerSigningKey = new SymmetricSecurityKey(key),
        //                ValidateIssuer = false,
        //                ValidateAudience = false
        //            };
        //        });

        //    return services;
        //}

        public static IServiceCollection AddAppServices(this IServiceCollection services) => services
            .AddTransient<ISellerService, SellerService>()
            .AddTransient<IListingService, ListingService>();
          

        public static IServiceCollection AddSwagger(this IServiceCollection services) => services
            .AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo() {Title = "Seller API", Version = "v1"});
            });

        public static void AddApiControllers(this IServiceCollection services) =>
            services.AddControllers(option => option.Filters.Add<ModelOrNotFoundActionFilter>());

    }
}

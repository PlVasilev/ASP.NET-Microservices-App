using Refit;
using Seller.Listing.Gateway.Infrastructure.Extensions;
using Seller.Listing.Gateway.Services;
using Seller.Listing.Gateway.Services.Listing;
using Seller.Listing.Gateway.Services.Offer;
using Seller.Shared.Infrastructure;
using Seller.Shared.Services.Identity;

namespace Seller.Listing.Gateway
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            var serviceEndpoints = this.Configuration
                .GetSection(nameof(ServiceEndpoints))
                .Get<ServiceEndpoints>(config => config.BindNonPublicProperties = true);

            services
                .AddJwtAuthentication(this.Configuration)
                .AddScoped<ICurrentTokenService, CurrentTokenService>()
                .AddTransient<JwtHeaderAuthenticationMiddleware>()
                .AddSwagger()
                .AddControllers();

            services
                .AddRefitClient<IListingService>()
                .WithConfiguration(serviceEndpoints.Listing);
            
            services
                .AddRefitClient<IOfferService>()
                .WithConfiguration(serviceEndpoints.Offer);
        }

        
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment()) app.UseDeveloperExceptionPage();

            app
                .UseSwaggerUI()
                .UseHttpsRedirection()
                .UseRouting()
                .UseJwtHeaderAuthentication()
                .UseCors(x => x
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader())
                .UseAuthorization()
                .UseEndpoints(endpoints => endpoints.MapControllers());
        }
    }
}

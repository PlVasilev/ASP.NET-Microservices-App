using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Seller.Offers.Data;
using Seller.Offers.Infrastructure.Extensions;
using Seller.Shared.Infrastructure;

namespace Seller.Offers
{
    public class Startup
    {
        public Startup(IConfiguration configuration) => Configuration = configuration;
        
        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services) =>
        services
            .AddWebService<OffersDbContext>(this.Configuration)
            .AddAppServices()
            .AddSwagger()
            .AddApiControllers();

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseWebService(env)
                .Initialize();
        }
    }
}

using GreenPipes;
using MassTransit;

namespace Seller.Listings
{
    using Data;
    using Seller.Shared.Infrastructure;
    using Infrastructure.Extensions;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services) =>
            services
                .AddWebService<ListingsDbContext>(this.Configuration)
                .AddAppServices()
                .AddSwagger()
                //.AddMessaging()
                .AddMassTransit(mt =>
                    mt.AddBus(bus => Bus.Factory.CreateUsingRabbitMq(cfg =>
                    {
                        cfg.Host("localhost");
                    })))
                .AddMassTransitHostedService()
                .AddApiControllers();
        

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) =>
            app.UseWebService(env)
                .Initialize();

    }
}

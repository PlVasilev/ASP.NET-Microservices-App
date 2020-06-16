namespace Seller.Server
{
    using Infrastructure.Extensions;
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

        public void ConfigureServices(IServiceCollection services) =>
            services
                .AddDatabase(this.Configuration)
                .AddIdentity()
                .AddJwtAuthentication(services.GetAppSettings(this.Configuration))
                .AddAppServices()
                .AddSwagger()
                .AddApiControllers();

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment()) app.UseDatabaseErrorPage();
            
            app
                .UseSwaggerUI()
                .UseRouting()
                .UseCors(x => x
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader())
                .UseAuthentication()
                .UseAuthorization()
                .UseEndpoints(endpoints => endpoints.MapControllers())
                .ApplyMigrations();
        }
    }
}

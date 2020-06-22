

using System.Linq;
using Microsoft.AspNetCore.Identity;

namespace Seller.Server.Infrastructure.Extensions
{
    using Data;
    using System;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
 
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseSwaggerUI(this IApplicationBuilder app) => app
            .UseSwagger()
            .UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "Seller API");
                options.RoutePrefix = String.Empty;
            });
        

        public static void ApplyMigrations(this IApplicationBuilder app)
        {
            using var services = app.ApplicationServices.CreateScope();
            var context = services.ServiceProvider.GetRequiredService<SellerDbContext>();
            context.Database.EnsureCreated();

            if (context.Roles.Count() <= 1)
            {
                context.Roles.Add(new IdentityRole() { Name = "Admin", NormalizedName = "ADMIN" });
                context.Roles.Add(new IdentityRole() { Name = "User", NormalizedName = "USER" });
                context.Roles.Add(new IdentityRole() { Name = "Guest", NormalizedName = "GUEST" });
                context.SaveChanges();
            }

            var dbContext = services.ServiceProvider.GetService<SellerDbContext>();

            dbContext.Database.Migrate();
        }
    }
}

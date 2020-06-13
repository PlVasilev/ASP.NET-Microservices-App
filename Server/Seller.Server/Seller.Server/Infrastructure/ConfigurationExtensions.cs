namespace Seller.Server.Infrastructure
{
    using Microsoft.Extensions.Configuration;

    public static class ConfigurationExtensions
    {
        public static string GetDeaultConnectionString(this IConfiguration configuration)
            => configuration.GetConnectionString("DefaultConnection");
    }
}

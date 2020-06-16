namespace Seller.Server.Infrastructure.Extensions
{
    using System.Security.Claims;
    using System.Linq;

    public static class IdentityExtensions
    {
        public static string GetId(this ClaimsPrincipal user)
        {
            return user.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
        }
    }
}

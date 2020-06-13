namespace Seller.Server.Features.Identity.Services.Interfaces
{
    public interface IIdentityService
    {
        string GenerateJwtToken(string userId, string userName, string secret);
    }
}

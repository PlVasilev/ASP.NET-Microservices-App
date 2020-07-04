using System.Threading.Tasks;
using Seller.Identity.Data.Models;


namespace Seller.Identity.Features.Identity.Services.Interfaces
{
    public interface IIdentityService
    {
        string GenerateJwtToken(string userId, string userName, string secret);
        Task<User> Register(string username, string password);
        //Task<bool> CreateUserSeller(string firstName, string lastName, string userId);
    }
}

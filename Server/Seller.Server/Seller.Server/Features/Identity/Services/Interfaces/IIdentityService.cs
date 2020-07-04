using System.Threading.Tasks;
using Seller.Server.Data.Models;

namespace Seller.Server.Features.Identity.Services.Interfaces
{
    public interface IIdentityService
    {
        string GenerateJwtToken(string userId, string userName, string secret);
        Task<User> Register(string email, string username, string password, string phoneNumber);
        Task<bool> CreateUserSeller(string firstName, string lastName, string userId);
    }
}

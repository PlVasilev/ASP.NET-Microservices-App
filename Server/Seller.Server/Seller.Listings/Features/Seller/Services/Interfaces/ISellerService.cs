using System.Threading.Tasks;

namespace Seller.Listings.Features.Seller.Services.Interfaces
{
    public interface ISellerService
    {
        Task<string> GetIdByUser(string userId);
        Task<bool> CreateUserSeller(string userName, string firstName, string lastName, string email, string phoneNumber,string userId);
    }
}

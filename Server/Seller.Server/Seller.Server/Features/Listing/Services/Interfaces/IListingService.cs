using System.Threading.Tasks;

namespace Seller.Server.Features.Listing.Services.Interfaces
{
    public interface IListingService
    {
        public Task<string> Create(string title, string description, string imageUrl, decimal price, string userId);

    }
}

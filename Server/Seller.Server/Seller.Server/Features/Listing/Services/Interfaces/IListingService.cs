using System.Threading.Tasks;
using Seller.Server.Data.Models;
using Seller.Server.Features.Listing.Models;

namespace Seller.Server.Features.Listing.Services.Interfaces
{
    public interface IListingService
    {
        public Task<ListingCreateResponseModel> Create(string title, string description, string imageUrl, decimal price, string userId);

    }
}

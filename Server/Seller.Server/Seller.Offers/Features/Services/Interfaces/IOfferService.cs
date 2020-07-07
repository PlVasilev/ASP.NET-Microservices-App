namespace Seller.Offers.Features.Services.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Models;
    public interface IOfferService
    {
        Task<OfferResponceModel> Add(decimal price, string creatorId, string listingId);
        Task<List<OfferResponceModel>> All(string listingId);
        Task<bool> Accept(string id);
        Task<decimal> GetCurrentOffer(string creatorId, string listingId);
    }
}

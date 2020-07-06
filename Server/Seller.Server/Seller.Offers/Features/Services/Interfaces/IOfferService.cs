using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Seller.Offers.Features.Models;

namespace Seller.Offers.Features.Services.Interfaces
{
    public interface IOfferService
    {
        Task<OfferResponceModel> Add(decimal price, string creatorId, string listingId);
        Task<List<OfferResponceModel>> All(string listingId);
        Task<bool> Accept(string id);
    }
}

using System.Threading.Tasks;
using Seller.Listings.Features.Deal.Models;

namespace Seller.Listings.Features.Deal.Services.Interfaces
{
    public interface IDealService
    {
        Task<bool> Create(DealCreateRequestModel model);
    }
}

namespace Seller.Listings.Features.Deal.Services
{
    using System;
    using System.Threading.Tasks;
    using Interfaces;
    using Models;
    using Data.Models;
    using Data;

    public class DealService : IDealService
    {
        private readonly ListingsDbContext context;

        public DealService(ListingsDbContext context)
        {
            this.context = context;
        }

        public async Task<bool> Create(DealCreateRequestModel model)
        {
            var deal = new Deal
            {
                Id = Guid.NewGuid().ToString(),
                Title = model.Title,
                BuyerId = model.BuyerId,
                CreatedOn = DateTime.UtcNow,
                IsDeleted = false,
                ListingId = model.ListingId,
                Price = model.Price,
                SellerId = model.SellerId
            };

            context.Add(deal);
            var result = await context.SaveChangesAsync();

            return result != 0;
        }
    }
}

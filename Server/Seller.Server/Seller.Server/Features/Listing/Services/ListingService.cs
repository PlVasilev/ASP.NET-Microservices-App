using Seller.Server.Features.Listing.Models;

namespace Seller.Server.Features.Listing.Services
{
    using System;
    using System.Threading.Tasks;
    using Data;
    using Interfaces;
    public class ListingService : IListingService
    {
        private readonly SellerDbContext context;

        public ListingService(SellerDbContext context)
        {
            this.context = context;
        }
        public async Task<ListingCreateResponseModel> Create(string title, string description, string imageUrl, decimal price, string userId)
        {

            var listing = new Data.Models.Listing()
            {
                Id = Guid.NewGuid().ToString(),
                Title = title,
                Created = DateTime.UtcNow,
                Description = description,
                ImageUrl = imageUrl,
                Price = price,
                IsDeleted = false,
                SellerId = userId
            };

            context.Add(listing); 
            await context.SaveChangesAsync();

            return new ListingCreateResponseModel()
            {
                Id = listing.Id,
                Title = listing.Title,
                Created = listing.Created,
                Description = listing.Description,
                ImageUrl = listing.ImageUrl,
                Price = listing.Price,
                IsDeleted = listing.IsDeleted,
                SellerId = listing.SellerId
            };
        }

    }
}

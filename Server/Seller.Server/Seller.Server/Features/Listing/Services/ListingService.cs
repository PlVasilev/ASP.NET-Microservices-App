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
        public async Task<string> Create(string title, string description, string imageUrl, decimal price, string userId)
        {

            var listing = new Data.Models.Listing()
            {
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

            return listing.Id;
        }

    }
}

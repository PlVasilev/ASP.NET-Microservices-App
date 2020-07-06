namespace Seller.Listings.Features.Listing.Services
{
    using System;
    using System.Threading.Tasks;
    using Data;
    using Interfaces;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.EntityFrameworkCore;
    using Models;
    public class ListingService : IListingService
    {
        private readonly ListingsDbContext context;

        public ListingService(ListingsDbContext context)
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

        public async Task<ListingDetailsResponseModel> Details(string id) => await this.context
            .Listings
            .Where(l => l.IsDeleted == false && l.Id == id)
            .Select(l => new ListingDetailsResponseModel()
            {
                Id = l.Id,
                Title = l.Title,
                ImageUrl = l.ImageUrl,
                Price = l.Price,
                Description = l.Description,
                OffersCount = 0,
                SellerId = l.SellerId,
                SellerName = l.Seller.FirstName + " " + l.Seller.LastName,
                Created = l.Created.ToString("D")
            }).FirstOrDefaultAsync();

        public async Task<bool> Update(string id, string title, string description, string imageUrl, decimal price, string userId)
        {
            var listing = await this.context
                .Listings
                .Where(l => l.Id == id && l.SellerId == userId && l.IsDeleted == false)
                .FirstOrDefaultAsync();

            if (listing == null) return false;

            listing.Title = title;
            listing.Description = description;
            listing.ImageUrl = imageUrl;
            listing.Price = price;
            listing.Created = DateTime.UtcNow;

            await context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(string id,string userId)
        {
            var listing = await this.context
                .Listings
                .Where(l => l.Id == id && l.SellerId == userId && l.IsDeleted == false)
                .FirstOrDefaultAsync();

            if (listing == null) return false;

            listing.IsDeleted = true;
            await context.SaveChangesAsync();
            return true;
        }


        public async Task<IEnumerable<ListingAllResponseModel>> All() => await this.context
            .Listings
            .Where(l => l.IsDeleted == false)
            .OrderByDescending(l => l.Created)
            .Select(l => new ListingAllResponseModel
            {
                Id = l.Id,
                Title = l.Title,
                ImageUrl = l.ImageUrl,
                Price = l.Price,
                Created = l.Created.ToString("D")
            }).ToListAsync();


        public async Task<IEnumerable<ListingAllResponseModel>> Mine(string userId) => await this.context
            .Listings
            .Where(l => l.SellerId == userId && l.IsDeleted == false)
            .OrderByDescending(l => l.Created)
            .Select(l => new ListingAllResponseModel
            {
                Id = l.Id,
                Title = l.Title,
                ImageUrl = l.ImageUrl,
                Price = l.Price,
                Created = l.Created.ToString("D")
            }).ToListAsync();


    }
}

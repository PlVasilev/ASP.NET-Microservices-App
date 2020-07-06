using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Seller.Offers.Features.Services
{
    using System;
    using System.Threading.Tasks;
    using Seller.Offers.Data.Models;
    using Microsoft.AspNetCore.Mvc;
    using Data;
    using Models;
    using Interfaces;
    public class OfferService : IOfferService
    {
        private readonly OffersDbContext context;

        public OfferService(OffersDbContext context)
        {
            this.context = context;
        }

        public async Task<OfferResponceModel> Add(decimal price, string creatorId, string listingId)
        {
            var offer = context.Offers.FirstOrDefaultAsync(x => 
                x.CreatorId == creatorId && 
                x.ListingId == listingId && 
                x.IsAccepted == false).Result;

            if (offer != null)
            {
                offer.Price = price;
                context.Update(offer);
            }
            else
            {
                var newOffer = new Offer
                {
                    Id = Guid.NewGuid().ToString(),
                    CreatorId = creatorId,
                    Created = DateTime.UtcNow,
                    Price = price,
                    ListingId = listingId,
                    IsAccepted = false
                };
                context.Add(newOffer);
            }

            await context.SaveChangesAsync();

            return new OfferResponceModel()
            {
                Id = offer.Id,
                CreatorId = offer.CreatorId,
                Created = offer.Created.ToString("g"),
                ListingId = offer.ListingId,
                Price = offer.Price,
                IsAccepted = offer.IsAccepted
            };
        }

        public async Task<List<OfferResponceModel>> All(string listingId) => await
            context
                .Offers
                .Where(x => x.ListingId == listingId && x.IsAccepted == false)
                .Select(x => new OfferResponceModel
                {
                    Price = x.Price,
                    CreatorId = x.CreatorId,
                    Id = x.Id,
                    ListingId = x.ListingId,
                    Created = x.Created.ToString("g")
                }).ToListAsync();

        public async Task<bool> Accept(string id)
        {
           var offer = await context.Offers.FirstOrDefaultAsync(x => x.Id == id);

           context.Offers.Update(offer);

           var result = await context.SaveChangesAsync();

           return result != 0;
        } 
       
    }
}



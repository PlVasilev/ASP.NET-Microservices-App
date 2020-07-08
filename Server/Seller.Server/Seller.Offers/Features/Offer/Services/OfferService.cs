﻿namespace Seller.Offers.Features.Offer.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Threading.Tasks;
    using Seller.Offers.Data.Models;
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
                 offer = new Offer
                {
                    Id = Guid.NewGuid().ToString(),
                    CreatorId = creatorId,
                    Created = DateTime.UtcNow,
                    Price = price,
                    ListingId = listingId,
                    IsAccepted = false
                };
                context.Add(offer);
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

           offer.IsAccepted = true;

           context.Offers.Update(offer);

           var result = await context.SaveChangesAsync();

           return result != 0;
        }

        public async Task<int> GetOffersCount(string id) =>
            await context.Offers.Where(x => x.ListingId == id && x.IsAccepted == false).CountAsync();
       

        public async Task<decimal> GetCurrentOffer(string creatorId, string listingId)
        {
            var offer = await context.Offers.FirstOrDefaultAsync(x =>
                x.CreatorId == creatorId && x.ListingId == listingId && x.IsAccepted == false);
            if (offer == null)
            {
                return 0;
            }

            return offer.Price;
        }
    }
}


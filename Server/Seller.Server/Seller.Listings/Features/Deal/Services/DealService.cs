﻿using MassTransit;
using Microsoft.EntityFrameworkCore;
using Seller.Shared.Messages.Offers;

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
        private readonly IBus publisher;

        public DealService(ListingsDbContext context, IBus publisher)
        {
            this.context = context;
            this.publisher = publisher;
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

            var listing = await this.context.Listings.FirstOrDefaultAsync(x => x.Id == model.ListingId);
            listing.IsDeal = true;

            context.Add(deal);
            context.Listings.Update(listing);

            var result = await context.SaveChangesAsync();

            await this.publisher.Publish(new ListingAcceptedMessage
            {
                ListingId = model.OfferId
            });

            return result != 0;
        }
    }
}
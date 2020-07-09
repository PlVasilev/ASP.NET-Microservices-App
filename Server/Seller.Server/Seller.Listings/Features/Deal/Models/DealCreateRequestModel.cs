﻿namespace Seller.Listings.Features.Deal.Models
{
    public class DealCreateRequestModel
    {
        public string Title { get; set; }
        public decimal Price { get; set; }
        public string ListingId { get; set; }
        public string SellerId { get; set; }
        public string BuyerId { get; set; }
    }
}

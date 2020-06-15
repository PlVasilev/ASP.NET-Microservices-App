﻿namespace Seller.Server.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Microsoft.AspNetCore.Identity;
    public class User : IdentityUser
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public bool IsDeleted { get; set; } 

        public IEnumerable<Deal> SaleDeals { get; set; } = new List<Deal>();
        public IEnumerable<Deal> BuyDeals { get; set; } = new List<Deal>();
        public IEnumerable<Offer> Offers { get; set; } = new List<Offer>();
        public IEnumerable<Listing> Listings { get; set; } = new List<Listing>();
        public IEnumerable<Message> Messages { get; set; } = new List<Message>();

    }
}
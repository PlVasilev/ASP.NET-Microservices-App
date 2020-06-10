using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Seller.Server.Data.Models
{
    using Microsoft.AspNetCore.Identity;
    public class User : IdentityUser
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public ICollection<Deal> SaleDeals { get; set; } = new List<Deal>();
        public ICollection<Deal> BuyDeals { get; set; } = new List<Deal>();
        public ICollection<Offer> Offers { get; set; } = new List<Offer>();
        public ICollection<Listing> Listings { get; set; } = new List<Listing>();
        public ICollection<Message> Messages { get; set; } = new List<Message>();

    }
}
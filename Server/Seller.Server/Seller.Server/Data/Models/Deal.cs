﻿namespace Seller.Server.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Deal
    {
        [Key]
        public string Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Range(typeof(decimal), "0.01", "79228162514264337593543950335")]
        public decimal Price { get; set; }

        [Required]
        public string ListingId { get; set; }

        [Required]
        public Listing Listing { get; set; }

        [Required]
        public string SellerId { get; set; }
        public UserSS Seller { get; set; }


        [Required]
        public string BuyerId { get; set; }
        public UserSS Buyer { get; set; }

        public bool IsDeleted { get; set; } 

    }
}

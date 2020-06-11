﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Seller.Server.Data.Models;

namespace Seller.Server.Models.Listing
{
    public class ListingCreateRequestModel
    {
        [Key]
        public string Id { get; set; }

        [Required]
        public string Title { get; set; }
        [Required]
        public string ImageUrl { get; set; }
        [Required]
        public string Description { get; set; }

        [Range(typeof(decimal), "0.01", "79228162514264337593543950335")]
        public decimal Price { get; set; }

        public ICollection<Offer> Offers { get; set; } = new List<Offer>();

        [Required]
        public string SellerId { get; set; }
        [Required]
        public User Seller { get; set; }

        public bool IsDeleted { get; set; } = false;
    }
}

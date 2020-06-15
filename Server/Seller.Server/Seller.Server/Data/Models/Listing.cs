namespace Seller.Server.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    public class Listing
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

        [Required]
        public DateTime Created { get; set; }

        public string DealId { get; set; }
        public Deal Deal { get; set; } 

        public IEnumerable<Offer> Offers { get; set; } = new List<Offer>();

        [Required]
        public string SellerId { get; set; }
        public User Seller { get; set; }

        public bool IsDeleted { get; set; }

    }
}

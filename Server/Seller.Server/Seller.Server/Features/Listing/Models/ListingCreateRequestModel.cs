namespace Seller.Server.Features.Listing.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Seller.Server.Data.Models;
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

        public bool IsDeleted { get; set; } = false;
    }
}

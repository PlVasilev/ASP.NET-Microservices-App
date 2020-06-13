namespace Seller.Server.Data.Models
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
        [Required]
        public User Seller { get; set; }


        [Required]
        public string BuyerId { get; set; }
        [Required]
        public User Buyer { get; set; }

        public bool IsDeleted { get; set; } 

    }
}

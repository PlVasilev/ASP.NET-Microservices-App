using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Seller.Server.Data.Models
{
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

        public string DealId { get; set; } = null;
        public Deal Deal { get; set; } = null;

        public ICollection<Offer> Offers { get; set; } = new List<Offer>();

        [Required]
        public User Seller { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Seller.Server.Data.Models
{
    public class Deal
    {
        [Key]
        public string Id { get; set; }

        [Range(typeof(decimal), "0.01", "79228162514264337593543950335")]
        public decimal Price { get; set; }

   
        [Required]
        public Listing Listing { get; set; }

        [Required]
        public User Seller { get; set; }

        [Required]
        public User Buyer { get; set; }

    }
}

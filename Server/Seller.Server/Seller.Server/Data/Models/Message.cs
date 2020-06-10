using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Seller.Server.Data.Models
{
    public class Message
    {
        [Key]
        public string Id { get; set; }

        [Required]
        public User Sender { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Content { get; set; }
        [Required]
        public DateTime Created { get; set; }
    }
}

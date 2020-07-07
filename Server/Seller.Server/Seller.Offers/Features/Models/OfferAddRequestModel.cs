using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Seller.Offers.Features.Models
{
    public class OfferAddRequestModel
    {
        public decimal Price { get; set; }
        public string CreatorId { get; set; }
        public string ListingId { get; set; }
    }
}
    

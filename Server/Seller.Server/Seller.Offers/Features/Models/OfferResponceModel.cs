namespace Seller.Offers.Features.Models
{
    public class OfferResponceModel
    {
        public string Id { get; set; }

        public string ListingId { get; set; }

        public decimal Price { get; set; }

        public string Created { get; set; }

        public string CreatorId { get; set; }

        public bool IsAccepted { get; set; }
    }
}

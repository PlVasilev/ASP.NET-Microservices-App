using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Seller.Listing.Gateway.Models.Offers;
using Seller.Listing.Gateway.Services.Listing;
using Seller.Listing.Gateway.Services.Offer;
using Seller.Shared.Controllers;

namespace Seller.Listing.Gateway.Controllers
{
    public class ListingController : ApiController
    {
        private readonly IListingService listingService;
        private readonly IOfferService offerService;

        public ListingController(IListingService listingService, IOfferService offerService)
        {
            this.listingService = listingService;
            this.offerService = offerService;
        }

        [HttpGet]
        [Authorize]
        [Route("OffersAll/{id}")]
        public async Task<List<OfferResponceModelWithName>> OffersAll(string id)
        {

            var listing = await listingService.GetTitleAndSellerName(id);
            var offers = await offerService.All(id);

            

            var result = new List<OfferResponceModelWithName>();

            foreach (var offerResponceModel in offers)
            {
                result.Add(new OfferResponceModelWithName
                {
                    Created = offerResponceModel.Created,
                    CreatorId = offerResponceModel.CreatorId,
                    Id = offerResponceModel.Id,
                    ListingId = offerResponceModel.ListingId,
                    Price = offerResponceModel.Price,
                    SellerName = listing.SellerName,
                    Title = listing.Title
                });
            }

            return result;
        }
    }
}

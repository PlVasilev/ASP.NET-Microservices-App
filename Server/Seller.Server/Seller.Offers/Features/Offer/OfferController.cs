using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Seller.Offers.Features.Offer.Models;
using Seller.Offers.Features.Offer.Services.Interfaces;
using Seller.Shared.Controllers;

namespace Seller.Offers.Features.Offer
{
    [Authorize]
    public class OfferController : ApiController
    {
        private readonly IOfferService offerService;

        public OfferController(IOfferService offerService)
        {
            this.offerService = offerService;
        }

        [HttpPost]
        [Route(nameof(Add))]
        public async Task<ActionResult<OfferResponceModel>> Add(OfferAddRequestModel model) =>
            await offerService.Add(model.Price, model.CreatorId, model.ListingId);


        [HttpPost]
        [Route(nameof(GetCurrentOffer))]
        public async Task<ActionResult<decimal>> GetCurrentOffer(OfferCurrentRequestModel model) =>
            await offerService.GetCurrentOffer(model.CreatorId, model.ListingId);

        [HttpGet]
        [Route("All/{id}")]
        public async Task<ActionResult<List<OfferResponceModel>>> All(string id) =>
            await offerService.All(id);

        [HttpGet]
        [Route("accept/{id}")]
        public async Task<ActionResult<bool>> Accept(string id) =>
            await offerService.Accept(id);

        [HttpGet]
        [Route("count/{id}")]
        public async Task<ActionResult<int>> Count(string id) =>
            await offerService.GetOffersCount(id);
    }
}

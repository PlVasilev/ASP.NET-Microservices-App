﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Seller.Offers.Features.Models;
using Seller.Offers.Features.Services.Interfaces;
using Seller.Shared.Controllers;
using Seller.Shared.Services.Identity;

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
        [Route(nameof(All))]
        public async Task<ActionResult<List<OfferResponceModel>>> All(string listingId) =>
            await offerService.All(listingId);

        [HttpPut]
        [Route(nameof(Accept))]
        public async Task<ActionResult<bool>> Accept(string id) =>
            await offerService.Accept(id);
    }
}

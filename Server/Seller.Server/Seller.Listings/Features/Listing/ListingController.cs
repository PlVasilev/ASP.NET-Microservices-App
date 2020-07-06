﻿using Seller.Shared;
using Seller.Shared.Controllers;
using Seller.Shared.Services.Identity;

namespace Seller.Listings.Features.Listing
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Models;
    using Services.Interfaces;

    [Authorize]
    public class ListingController : ApiController
    {

        private readonly IListingService listingService;
        private readonly ICurrentUserService currentUser;

        public ListingController(IListingService listingService, ICurrentUserService currentUser)
        {
            this.listingService = listingService;
            this.currentUser = currentUser;
        }

 
        [HttpGet]
        [Route(nameof(All))]
        public async Task<IEnumerable<ListingAllResponseModel>> All() => await listingService.All();

        [HttpGet]
        [Route(nameof(Mine))]
        public async Task<IEnumerable<ListingAllResponseModel>> Mine() => await listingService.Mine(UserId());

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<ListingDetailsResponseModel>> Details(string id) => await listingService.Details(id);

        [HttpPut]
        [Route(nameof(Update))]
        public async Task<ActionResult> Update(ListingUpdateRequestModel model)
        {
            var updated = await listingService.Update(model.Id, model.Title, model.Description, model.ImageUrl,
                model.Price, UserId());

            if (!updated) return BadRequest();
            
            return Ok();
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            var deleted = await listingService.Delete(id, UserId());

            if (!deleted) return BadRequest();
            
            return Ok();
        }

        [HttpPost]
        [Route(nameof(Create))]
        public async Task<ActionResult<ListingCreateResponseModel>> Create(ListingCreateRequestModel model) => await 
            listingService.Create(model.Title, model.Description, model.ImageUrl, model.Price, UserId());

        private string UserId() => currentUser.UserId;

    }
}
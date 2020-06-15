namespace Seller.Server.Features.Listing
{
    using System.Collections.Generic;
    using Features;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Infrastructure;
    using Models;
    using Services.Interfaces;

    public class ListingController : ApiController
    {

        private readonly IListingService listingService;

        public ListingController(IListingService listingService)
        {
            this.listingService = listingService;
        }

        [Authorize]
        [HttpGet]
        [Route(nameof(All))]
        public async Task<IEnumerable<ListingAllResponseModel>> All() => await
            listingService.All();

        [Authorize]
        [HttpGet]
        [Route(nameof(Mine))]
        public async Task<IEnumerable<ListingAllResponseModel>> Mine() => await 
            listingService.Mine(UserId());


        [Authorize]
        [HttpPost]
        [Route(nameof(Create))]
        public async Task<ActionResult<ListingCreateResponseModel>> Create(ListingCreateRequestModel model) => await 
            listingService.Create(model.Title, model.Description, model.ImageUrl, model.Price, UserId());

        private string UserId() => User.GetId();

    }
}

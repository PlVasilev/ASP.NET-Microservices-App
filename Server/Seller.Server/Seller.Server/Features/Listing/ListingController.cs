namespace Seller.Server.Features.Listing
{
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
        [HttpPost]
        [Route(nameof(Create))]
        public async Task<ActionResult<ListingCreateResponseModel>> Create(ListingCreateRequestModel model)
        {
            var userId = User.GetId();

            return await listingService.Create(model.Title, model.Description, model.ImageUrl, model.Price, userId);
        }
    }
}

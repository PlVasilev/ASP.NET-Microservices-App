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
        public async Task<ActionResult<string>> Create(ListingCreateRequestModel model)
        {
            var userId = User.GetId();

            var id = await listingService.Create(model.Title, model.Description, model.ImageUrl, model.Price, userId);

            return Created(nameof(this.Create), id);
        }
    }
}

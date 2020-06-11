using System;
using Seller.Server.Data;
using Seller.Server.Data.Models;

namespace Seller.Server.Controllers
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Models.Listing;
    using Infrastructure;

    public class ListingController : ApiController
    {
        private readonly SellerDbContext context;

        public ListingController(SellerDbContext context)
        {
            this.context = context;
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult<string>> Create(ListingCreateRequestModel model)
        {
            var userId = User.GetId();

            var listing = new Listing()
            {
                Title = model.Title,
                Created = DateTime.UtcNow,
                Description = model.Description,
                ImageUrl = model.ImageUrl,
                Price = model.Price,
                IsDeleted = false,
                SellerId = userId
            };

            context.Add(listing);
            await context.SaveChangesAsync();

            return Created(nameof(this.Create), listing.Id);
        }
    }
}

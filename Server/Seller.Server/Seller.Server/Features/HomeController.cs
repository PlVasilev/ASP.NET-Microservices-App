namespace Seller.Server.Features
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Authorization;

    public class HomeController : ApiController
    {
        [HttpGet]
        [Authorize]
        public ActionResult Get()
        {
            return Ok("Works");
        }
    }
}

using Microsoft.AspNetCore.Authorization;

namespace Seller.Server.Controllers
{
    using System;
    using Microsoft.AspNetCore.Mvc;

    public class HomeController : ApiController
    {
       [Authorize]
        public ActionResult Get()
        {
            return Ok("Works");
        }
    }
}

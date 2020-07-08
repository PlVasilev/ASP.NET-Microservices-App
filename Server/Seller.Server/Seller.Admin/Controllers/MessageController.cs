using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Seller.Admin.Services.Message;

namespace Seller.Admin.Controllers
{
    public class MessageController : AdministrationController
    {
        private readonly IMessageService message;

        public MessageController(IMessageService message)
            => this.message = message;

        public async Task<IActionResult> Index()
            => View(await this.message.All());

        public async Task<IActionResult> Process()
            => View(await this.message.All());
    }
}

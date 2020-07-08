using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Seller.Messages.Features.Message.Models;
using Seller.Messages.Features.Message.Services.Interfaces;

namespace Seller.Messages.Features.Message
{
    using Microsoft.AspNetCore.Authorization;
    using Shared.Controllers;

    [Authorize]
    public class MessageController : ApiController
    {
        private readonly IMessageService messageService;

        public MessageController(IMessageService messageService)
        {
            this.messageService = messageService;
        }

        [HttpPost]
        [Route(nameof(Add))]
        public async Task<ActionResult<bool>> Add(MessageRequestModel model) =>
            await messageService.Add(model.SenderId, model.SenderUsername, model.Title, model.Content);

        [HttpGet]
        [Route(nameof(All))]
        public async Task<ActionResult<List<MessageResponseModel>>> All() =>
            await messageService.All();

        [HttpGet]
        [Route("process/{id}")]
        public async Task<ActionResult<bool>> Process(string id) =>
            await messageService.Process(id);
    }
}

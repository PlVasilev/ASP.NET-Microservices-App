﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Refit;
using Seller.Admin.Models.Message;

namespace Seller.Admin.Services.Message
{
   public interface IMessageService
    {
        [Get("/Message/All")]
        Task<List<MessageResponseModel>> All();
    }
}
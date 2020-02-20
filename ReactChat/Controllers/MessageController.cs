using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReactChat.BusinessLogicLayer.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReactChat.Controllers
{
    [ApiController]
    [AllowAnonymous]
    [Route("Message")]
    public class MessageController:ControllerBase
    {
        private readonly IMessageService _messageService;
        public MessageController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(string id)
        {
            return Ok();
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            return Ok();
        }

        [HttpGet("GetByAccount")]
        public async Task<IActionResult> GetByAccount(string accountId)
        {
            return Ok();
        }

        [HttpGet("GetByChat")]
        public async Task<IActionResult> GetByChat(string chatId)
        {
            return Ok();
        }

    }
}

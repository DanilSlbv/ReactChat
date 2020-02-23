using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ReactChat.BusinessLogicLayer.Services.Interfaces;

namespace ReactChat.Controllers
{
    [ApiController]
    [AllowAnonymous]
    [Route("ApplicationUser")]
    public class ApplicationUserController : ControllerBase
    {
        private readonly IApplicationUserService _applicationUserService;
        public ApplicationUserController(IApplicationUserService applicationUserService)
        {
            _applicationUserService = applicationUserService;
        }

        [HttpGet]
        [Route("CreateAccount")]
        public async Task<IActionResult> CreateAccount(string phoneNumber)
        {
            var result = await _applicationUserService.CheckIfUserExist(phoneNumber);
            return Ok(result);
        }

        [HttpPost]
        [Route("SendVerification")]
        public IActionResult ReSendVerification(string phoneNumber)
        {
            return Ok();
        }

       

    }
}

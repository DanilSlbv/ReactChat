using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ReactChat.BusinessLogicLayer.Models;
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
            var result = await _applicationUserService.CheckIfUserExistAsync(phoneNumber);
            return Ok(result);
        }

        [HttpPost]
        [Route("SendVerification")]
        public IActionResult ReSendVerification(string phoneNumber)
        {
            return Ok();
        }

        [HttpPost]
        [Route("AdditionalSecurityVerify")]
        public async Task<IActionResult> AdditionalSecurityVerify(SignInModel signInModel)
        {
            var result = await _applicationUserService.AdditionalSecurityVerificationAsync(signInModel);
            return Ok(result);
        }

        

    }
}

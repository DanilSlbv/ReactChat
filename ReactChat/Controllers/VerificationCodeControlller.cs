using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReactChat.BusinessLogicLayer.Models;
using ReactChat.BusinessLogicLayer.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReactChat.Controllers
{
    [ApiController]
    [AllowAnonymous]
    [Route("VerificationCode")]
    public class VerificationCodeControlller : ControllerBase
    {
        private readonly IVerificationCodeService _verificationCodeService;

        public VerificationCodeControlller(IVerificationCodeService verificationCodeService)
        {
            _verificationCodeService = verificationCodeService;
        }

        [HttpPost]
        [Route("ConfirmCode")]
        public async Task<IActionResult> ConfirmCode(VerificationCodeModel verificationCodeModel)
        {
            var result = await _verificationCodeService.ConfirmCode(verificationCodeModel);
            return Ok(result);
        }

    }
}

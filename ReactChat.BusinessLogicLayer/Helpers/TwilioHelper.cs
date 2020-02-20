using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace ReactChat.BusinessLogicLayer.Helpers
{
    public class TwilioHelper
    {
        private readonly IConfiguration _configuration;
        public TwilioHelper(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<string> SendMessage(string phoneNumber, string code)
        {
            TwilioClient.Init(_configuration.GetSection("Twilio").GetSection("SID").Value, _configuration.GetSection("Twilio").GetSection("TOKEN").Value);
            var message = await MessageResource.CreateAsync(
                body: "Your verification code:" + code,
                from: new Twilio.Types.PhoneNumber("+12053464515"),
                to: new Twilio.Types.PhoneNumber(phoneNumber)
                );
            return message.ErrorMessage;
        }
    }
}

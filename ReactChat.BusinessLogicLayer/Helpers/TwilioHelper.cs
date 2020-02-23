using Microsoft.Extensions.Configuration;
using ReactChat.BusinessLogicLayer.Common.Constants;
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
        public async Task<string> SendMessage(string phoneNumber, string code)
        {
            try
            {
                TwilioClient.Init(Constants.TwilioConstants.Sid, Constants.TwilioConstants.Token);
                var message = await MessageResource.CreateAsync(
                    body: "Your verification code:" + code,
                    from: new Twilio.Types.PhoneNumber("+12053464515"),
                    to: new Twilio.Types.PhoneNumber("+"+phoneNumber)
                    );
                return message.ErrorMessage;
            }catch(Exception ex)
            {
                return null;
            }
        }
    }
}

using ReactChat.BusinessLogicLayer.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReactChat.BusinessLogicLayer.Models
{
    public class SignInResponse
    {
        public bool IsNewUser { get; set; }
        public bool Result { get; set; }
        public string PhoneNumber { get; set; }
        public string VerificationCode { get; set; }
        public string Message { get; set; }
        public AdditionalSecurity AdditionalSecurity { get; set; }
        public SignInResponse()
        {
            IsNewUser = false;
            Result = false;
            AdditionalSecurity = AdditionalSecurity.None;
        }

    }
}

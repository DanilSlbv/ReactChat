using System;
using System.Collections.Generic;
using System.Text;

namespace ReactChat.BusinessLogicLayer.Models
{
    public class SignInModel
    {
        public string PhoneNumber { get; set; }
        public string UserName { get; set; }
        public string VerificationCode { get; set; }
        public string Password { get; set; }
        public string PinCode { get; set; }
    }
}

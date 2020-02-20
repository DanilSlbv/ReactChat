using System;
using System.Collections.Generic;
using System.Text;

namespace ReactChat.BusinessLogicLayer.Models
{
    public class SignInModel
    {
        public string UserName { get; set; }
        public string VerificationCode { get; set; }
    }
}

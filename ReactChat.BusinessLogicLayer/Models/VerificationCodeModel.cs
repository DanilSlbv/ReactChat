using System;
using System.Collections.Generic;
using System.Text;

namespace ReactChat.BusinessLogicLayer.Models
{
    public class VerificationCodeModel
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public UserModel User { get; set; }
        public DateTime ExpiresOn { get; set; }
        public string Code { get; set; }
        public string PhoneNumber { get; set; }
    }
}

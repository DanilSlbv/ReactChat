using System;
using System.Collections.Generic;
using System.Text;

namespace ReactChat.DataAccessLayer.Entities
{
    public class VerificationCode : BaseEntity
    {
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }
        public DateTime ExpiresOn { get; set; }
        public string Code { get; set; }
        public VerificationCode()
        {
            ExpiresOn = CreateOn.AddMinutes(10.0);
        }
    }
}

using ReactChat.DataAccessLayer.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReactChat.DataAccessLayer.Entities
{
    public class Member:BaseEntity
    {
        public string ChatId { get; set; }
        public virtual Chat Chat { get; set; }
        public ChatRoles ChatRole { get; set; }
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}

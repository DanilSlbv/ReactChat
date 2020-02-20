using ReactChat.BusinessLogicLayer.Enums;
using ReactChat.DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReactChat.BusinessLogicLayer.Models
{
    public class MemberModel
    {
        public string ChatId { get; set; }
        public Chat Chat { get; set; }
        public string MemberId { get; set; }
        public Member Member { get; set; }
        public ChatRoles ChatRole { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace ReactChat.DataAccessLayer.Entities
{
    public class Message : BaseEntity
    {
        public string ChatId { get; set; }
        public virtual Chat Chat { get; set; }
        public string Text { get; set; }
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}

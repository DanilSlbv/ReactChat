using ReactChat.BusinessLogicLayer.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReactChat.BusinessLogicLayer.Models
{
    public class ChatModel
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string CreatedById { get; set; }
        public DateTime CreatedOn { get; set; }
        public ChatTypes ChatType { get; set; }
    }
}

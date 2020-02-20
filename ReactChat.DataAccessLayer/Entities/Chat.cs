using ReactChat.DataAccessLayer.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReactChat.DataAccessLayer.Entities
{
    public class Chat:BaseEntity
    {
        public string Title { get; set; }
        public string CreatorId { get; set; }
        public virtual ApplicationUser Creator { get; set; }
        public virtual ChatTypes ChatType { get; set; }
    }
}

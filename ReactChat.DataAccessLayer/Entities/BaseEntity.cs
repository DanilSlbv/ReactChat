using System;
using System.Collections.Generic;
using System.Text;

namespace ReactChat.DataAccessLayer.Entities
{
    public class BaseEntity
    {
        public string Id { get; set; }
        public DateTime CreateOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public bool Deleted { get; set; }
        public BaseEntity()
        {
            Deleted = false;
            CreateOn = DateTime.Now;
        }
    }
}

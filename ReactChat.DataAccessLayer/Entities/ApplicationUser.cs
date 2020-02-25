using Microsoft.AspNetCore.Identity;
using ReactChat.DataAccessLayer.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReactChat.DataAccessLayer.Entities
{
    public class ApplicationUser:IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public AdditionalSecurity AdditionalSecurity { get; set; }
        public string PinCodeHash { get; set; }
    }
}

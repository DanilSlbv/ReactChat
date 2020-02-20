using System;
using System.Collections.Generic;
using System.Text;

namespace ReactChat.BusinessLogicLayer.Helpers
{
    public class PasswordHelper
    {
        private string Password { get; set; }
        public PasswordHelper()
        {
            var pwd = new PasswordGenerator.Password().IncludeLowercase().IncludeUppercase().IncludeSpecial().LengthRequired(8);
            Password = pwd.Next();
        }

        public string GeneratePassword()
        {
            return Password;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace ReactChat.BusinessLogicLayer.Helpers
{
    public class PasswordGenerate
    {
        private string Password { get; set; }
        public PasswordGenerate()
        {
            var pwd = new PasswordGenerator.Password().IncludeLowercase().IncludeUppercase().LengthRequired(6);
            Password = pwd.Next();
        }

        public string GeneratePassword()
        {
            return Password;
        }
    }
}

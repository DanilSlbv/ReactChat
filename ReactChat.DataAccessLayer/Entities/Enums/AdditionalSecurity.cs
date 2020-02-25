using System;
using System.Collections.Generic;
using System.Text;

namespace ReactChat.DataAccessLayer.Entities.Enums
{
    public enum AdditionalSecurity
    {
        None = 0,
        PinCode = 1,
        Password = 2,
        PasswordAndPinCode = 3
    }
}

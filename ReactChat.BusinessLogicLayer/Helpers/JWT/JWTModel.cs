using System;
using System.Collections.Generic;
using System.Text;

namespace ReactChat.BusinessLogicLayer.Helpers.JWT
{
    public class JWTModel
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
    }
}

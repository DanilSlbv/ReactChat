using System;
using System.Collections.Generic;
using System.Text;

namespace ReactChat.BusinessLogicLayer.Models
{
    public class ResponseModel<T>
    {
        public bool Result { get; set; }
        public string Message { get; set; }
        public T Response { get; set; }
    }
}

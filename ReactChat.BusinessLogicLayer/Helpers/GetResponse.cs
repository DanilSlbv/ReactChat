using ReactChat.BusinessLogicLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReactChat.BusinessLogicLayer.Helpers
{
    public class GetResponse<T>
    {
        private readonly T _entity;
        public GetResponse(T entity)
        {
            _entity = entity;
        }
        public ResponseModel<T> GetSuccessResponse(string message=null)
        {
            
            return new ResponseModel<T>
            {
                Result = true,
                Message = string.IsNullOrWhiteSpace(message)?"Success":message,
                Response = _entity
            };
        }
        public ResponseModel<T>GetErrorResponse(string message)
        {
            return new ResponseModel<T>
            {
                Result = false,
                Message = message,
                Response = _entity
            };
        }
    }
}

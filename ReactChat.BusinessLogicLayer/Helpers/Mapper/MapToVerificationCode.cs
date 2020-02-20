using ReactChat.BusinessLogicLayer.Models;
using ReactChat.DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReactChat.BusinessLogicLayer.Helpers.Mapper
{
    public static class MapToVerificationCode
    {
        public static VerificationCode MapToVerificationCodeEntity(VerificationCodeModel verificationCodeModel)
        {
            return new VerificationCode
            {
                Id = verificationCodeModel.Id,
                UserId = verificationCodeModel.UserId,
                ExpiresOn = verificationCodeModel.ExpiresOn,
                Code = verificationCodeModel.Code
            };
        }
        public static VerificationCodeModel MapToVerificationCodeModel(VerificationCode verificationCode)
        {
            return new VerificationCodeModel
            {
                Id = verificationCode.Id,
                UserId = verificationCode.User.Id,
                User = MapApplicationUser.MapFromApplicationUser(verificationCode.User),
                ExpiresOn = verificationCode.ExpiresOn,
                Code = verificationCode.Code
            };
        }
    }
}

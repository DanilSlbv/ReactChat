using ReactChat.BusinessLogicLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ReactChat.BusinessLogicLayer.Services.Interfaces
{
    public interface IVerificationCodeService
    {
        Task<ResponseModel<string>> CreateAsync(VerificationCodeModel verificationCode);
        Task<ResponseModel<VerificationCodeModel>> GetByUserId(string userId);
        Task<bool> CheckIfExpired(string userId);
        Task<bool> ConfirmCode(VerificationCodeModel verificationCode);
        Task<bool> RemoveByPhoneNumber(string phoneNumber);
    }
}

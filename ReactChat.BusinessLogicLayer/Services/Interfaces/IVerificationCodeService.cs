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
        Task<ResponseModel<VerificationCodeModel>> GetByUserIdAsync(string userId);
        Task<bool> CheckIfExpiredAsync(string userId);
        Task<bool> ConfirmCodeAsync(SignInModel signInModel);
        Task<bool> RemoveByPhoneNumberAsync(string phoneNumber);
    }
}

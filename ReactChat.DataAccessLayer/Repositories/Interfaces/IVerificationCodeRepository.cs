using ReactChat.DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ReactChat.DataAccessLayer.Repositories.Interfaces
{
    public interface IVerificationCodeRepository:IBaseRepository<VerificationCode>
    {
        Task<bool> CheckExpireAsync(string userId);
        Task<VerificationCode> GetByCodeAsync(string code);
        Task<bool> RemoveItemByUserIdAsync(string userId);
        Task<bool> CheckCodeAndConfirmAsync(string phoneNumber, string verificationCode);
        Task<bool> RemoveCodeByPhoneNumberAsync(string phoneNumber);
        Task<bool> RemoveAllCodesByPhoneNumberAsync(string phoneNumber);
    }
}

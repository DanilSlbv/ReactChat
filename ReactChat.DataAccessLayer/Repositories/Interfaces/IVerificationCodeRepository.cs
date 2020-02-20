using ReactChat.DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ReactChat.DataAccessLayer.Repositories.Interfaces
{
    public interface IVerificationCodeRepository:IBaseRepository<VerificationCode>
    {
        Task<bool> CheckExpire(string userId);
        Task<VerificationCode> GetByCode(string code);
        Task<bool> RemoveItemByUserId(string userId);
        Task<bool> CheckCodeAndConfirm(VerificationCode verificationCode);
    }
}

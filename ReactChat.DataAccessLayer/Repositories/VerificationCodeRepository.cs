using Microsoft.EntityFrameworkCore;
using ReactChat.DataAccessLayer.Entities;
using ReactChat.DataAccessLayer.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReactChat.DataAccessLayer.Repositories
{
    public class VerificationCodeRepository : BaseRepository<VerificationCode>, IVerificationCodeRepository
    {
        private readonly ApplicationContext _context;
        public VerificationCodeRepository(ApplicationContext context) : base(context)
        {
            _context = context;
        }

        public async Task<bool> CheckExpire(string userId)
        {
            if (await _context.VerificationCodes.Where(x => x.Deleted == false && x.UserId == userId && x.ExpiresOn <= DateTime.UtcNow).FirstOrDefaultAsync() != null)
            {
                return true;
            }
            return false;
        }

        public async Task<VerificationCode> GetByCode(string code)
        {
            return await _context.VerificationCodes.Where(x => x.Code == code && x.Deleted == false && x.ExpiresOn <= DateTime.UtcNow).FirstOrDefaultAsync();
        }

        public async Task<bool> RemoveItemByUserId(string userId)
        {
            var item = await _context.VerificationCodes.Where(x => x.UserId == userId && x.Deleted == false).FirstOrDefaultAsync();
            if (item == null)
            {
                return false;
            }
            item.Deleted = true;
            var result = _context.VerificationCodes.Update(item);
            if (await _context.SaveChangesAsync() > 0)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> CheckCodeAndConfirm(VerificationCode verificationCode)
        {
            var code = await _context.VerificationCodes.Where(x => x.Deleted == false && x.UserId == verificationCode.UserId && x.Code == verificationCode.Code && x.ExpiresOn <= DateTime.Now).FirstOrDefaultAsync(); 
            if(code == null)
            {
                return false;
            }
            code.Deleted = true;
            _context.Update(code);
            if(await _context.SaveChangesAsync() > 0)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> RemoveCodeByPhoneNumber(string phoneNumber)
        {
            var result = await _context.VerificationCodes.Where(x => x.Deleted == false && x.User.PhoneNumber == phoneNumber && x.ExpiresOn <= DateTime.Now).FirstOrDefaultAsync();
            result.Deleted = true;
            _context.Update(result);
            if (await _context.SaveChangesAsync() > 0)
            {
                return true;
            }
            return false;
        }
    }
}

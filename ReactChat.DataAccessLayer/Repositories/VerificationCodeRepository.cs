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
        private readonly IApplicationUserRepository _applicationUserRepository;
        public VerificationCodeRepository(ApplicationContext context,IApplicationUserRepository applicationUserRepository) : base(context)
        {
            _context = context;
            _applicationUserRepository = applicationUserRepository;
        }

        public async Task<bool> CheckExpireAsync(string userId)
        {
            if (await _context.VerificationCodes.Where(x => x.Deleted == false && x.UserId == userId && x.ExpiresOn <= DateTime.UtcNow).FirstOrDefaultAsync() != null)
            {
                return true;
            }
            return false;
        }

        public async Task<VerificationCode> GetByCodeAsync(string code)
        {
            return await _context.VerificationCodes.Where(x => x.Code == code && x.Deleted == false && x.ExpiresOn <= DateTime.UtcNow).FirstOrDefaultAsync();
        }

        public async Task<bool> RemoveItemByUserIdAsync(string userId)
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

        public async Task<bool> CheckCodeAndConfirmAsync(string phoneNumber, string verificationCode)
        {
            var code = await _context.VerificationCodes.Where(x => x.Deleted == false && x.User.PhoneNumber==phoneNumber && x.Code == verificationCode && x.ExpiresOn <= DateTime.Now).FirstOrDefaultAsync(); 
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

        public async Task<bool> RemoveCodeByPhoneNumberAsync(string phoneNumber)
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

        public async Task<bool> RemoveAllCodesByPhoneNumberAsync(string phoneNumber)
        {
            var resultElements = new List<VerificationCode>();
            var elementsToRemove = await _context.VerificationCodes.Where(x => x.Deleted == false && x.User.PhoneNumber == phoneNumber && x.ExpiresOn <= DateTime.Now).ToListAsync();
            elementsToRemove.ForEach(x => { x.Deleted = true; resultElements.Add(x); });
            _context.VerificationCodes.UpdateRange(resultElements);
            if(await _context.SaveChangesAsync() > 0 || resultElements.Count()==0)
            {
                return true;
            }
            return false;
        }

    }
}

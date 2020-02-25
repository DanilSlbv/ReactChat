using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ReactChat.DataAccessLayer.Entities;
using ReactChat.DataAccessLayer.Entities.Enums;
using ReactChat.DataAccessLayer.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReactChat.DataAccessLayer.Repositories
{
    public class ApplicationUserRepository : IApplicationUserRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;
        public ApplicationUserRepository(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<ApplicationUser> GetUserByIdAsync(string id)
        {
            return await _userManager.FindByIdAsync(id);
        }

        public async Task<ApplicationUser> GetUserByEmailAsync(string userEmail)
        {
            var applicationUser = await _userManager.FindByEmailAsync(userEmail);
            return applicationUser;
        }

        public async Task<ApplicationUser> GetUserByPhoneNumberAsync(string phoneNumber)
        {
            var applicationUser = await _userManager.Users.Where(x => x.PhoneNumber == phoneNumber).FirstOrDefaultAsync();
            return applicationUser;
        }

        public async Task<List<string>> CreateAsync(ApplicationUser user)
        {
            var result = await _userManager.CreateAsync(user);
            await AddtoRoleAsync(user);
            return result.Errors.Select(x => x.Description).ToList();
        }

        public async Task<List<string>> DeleteUserAsync(string id)
        {
            var applicationUser = await GetUserByIdAsync(id);
            var result = await _userManager.DeleteAsync(applicationUser);
            return result.Errors.Select(x => x.Description).ToList();
        }

        public async Task<List<string>> EditUserAsync(ApplicationUser editUser)
        {
            var result = await _userManager.UpdateAsync(editUser);
            return result.Errors.Select(x => x.Description).ToList();
        }

        public async Task<bool> ConfirmPhoneNumberAsync(string userId)
        {
            var user = await _userManager.Users.Where(x => x.Id == userId).FirstOrDefaultAsync();
            if (user == null)
            {
                return false;
            }
            user.PhoneNumberConfirmed = true;
            var result = await _userManager.UpdateAsync(user);
            if (!result.Succeeded)
            {
                return false;
            }
            return true;
        }

        public async Task<bool> AddNewPasswordAsync(ApplicationUser applicationUser, AdditionalSecurity additionalSecurity, string passwordHash)
        {
            if ((double)additionalSecurity == 1)
            {
                applicationUser.PinCodeHash = passwordHash;
            }
            if ((double)additionalSecurity == 2)
            {
                applicationUser.PasswordHash = passwordHash;
            }
            var result = await _userManager.UpdateAsync(applicationUser);
            return result.Succeeded;
        }

        public async Task<string> GetPasswordHashAsync(string userId, AdditionalSecurity additionalSecurity)
        {
            var applicationUser = await _userManager.Users.Where(x => x.Id == userId).FirstOrDefaultAsync();
            if ((double)additionalSecurity == 1)
            {
                return applicationUser.PinCodeHash;
            }
            if((double)additionalSecurity == 2)
            {
                return applicationUser.PasswordHash;
            }
            return null;
        }

        private async Task<List<string>> AddtoRoleAsync(ApplicationUser applicationUser)
        {
            var result = await _userManager.AddToRoleAsync(applicationUser, "user");
            return result.Errors.Select(x => x.Description).ToList();
        }
    }
}

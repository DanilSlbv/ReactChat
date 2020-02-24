using Microsoft.AspNetCore.Identity;
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
    public class ApplicationUserRepository:IApplicationUserRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;
       // private readonly SignInManager<ApplicationUser> _signInManager;
        public ApplicationUserRepository(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            //_signInManager = signInManager;
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

        public async Task<bool> ConfirmPhoneNumber(string userId)
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

        private async Task<List<string>> AddtoRoleAsync(ApplicationUser applicationUser)
        {
            var result = await _userManager.AddToRoleAsync(applicationUser, "user");
            return result.Errors.Select(x => x.Description).ToList();
        }

    }
}

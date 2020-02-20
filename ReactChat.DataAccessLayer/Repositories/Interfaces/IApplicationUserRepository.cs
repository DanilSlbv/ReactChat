using ReactChat.DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ReactChat.DataAccessLayer.Repositories.Interfaces
{
    public interface IApplicationUserRepository
    {
        Task<ApplicationUser> GetUserByIdAsync(string id);
        Task<ApplicationUser> GetUserByEmailAsync(string userEmail);
        Task<ApplicationUser> GetUserByPhoneNumberAsync(string phoneNumber);
        Task<List<string>> CreateAsync(ApplicationUser user);
        Task<List<string>> DeleteUserAsync(string id);
        Task<List<string>> EditUserAsync(ApplicationUser editUser);
    }
}

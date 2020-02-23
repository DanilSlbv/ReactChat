using ReactChat.BusinessLogicLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ReactChat.BusinessLogicLayer.Services.Interfaces
{
    public interface IApplicationUserService
    {
        Task<ResponseModel<List<string>>> CreateAccountAsync(SignUpModel signUpModel);
        Task<ResponseModel<string>> CheckIfUserExist(string phoneNumber);
        Task<ResponseModel<List<string>>> CreateAccountByPhoneNumber(string phoneNumber);
    }
}

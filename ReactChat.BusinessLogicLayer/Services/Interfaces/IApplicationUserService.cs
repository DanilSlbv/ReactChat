using ReactChat.BusinessLogicLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ReactChat.BusinessLogicLayer.Services.Interfaces
{
    public interface IApplicationUserService
    {
        Task<SignInResponse> CheckIfUserExistAsync(string phoneNumber);
        Task<ResponseModel<List<string>>> CreateAccountByPhoneNumberAsync(string phoneNumber);
        Task<ResponseModel<List<string>>> CreateAccountAsync(SignInModel signUpModel);
        Task<ResponseModel<string>> AdditionalSecurityVerificationAsync(SignInModel signInModel);
    }
}

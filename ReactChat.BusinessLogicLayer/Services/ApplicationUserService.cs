using AutoMapper;
using ReactChat.BusinessLogicLayer.Enums;
using ReactChat.BusinessLogicLayer.Helpers;
using ReactChat.BusinessLogicLayer.Helpers.Encryption;
using ReactChat.BusinessLogicLayer.Helpers.Mapper;
using ReactChat.BusinessLogicLayer.Models;
using ReactChat.BusinessLogicLayer.Services.Interfaces;
using ReactChat.DataAccessLayer.Entities;
using ReactChat.DataAccessLayer.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ReactChat.BusinessLogicLayer.Services
{
    public class ApplicationUserService : IApplicationUserService
    {
        private readonly IApplicationUserRepository _userRepository;
        private readonly IVerificationCodeService _verificationCodeService;
        private readonly IMapper _mapper;
        public ApplicationUserService(IApplicationUserRepository userRepository,
                                      IVerificationCodeService verificationCodeService,
                                      IMapper mapper)
        {
            _userRepository = userRepository;
            _verificationCodeService = verificationCodeService;
            _mapper = mapper;
        }

        public async Task<SignInResponse> CheckIfUserExistAsync(string phoneNumber)
        {
            var response = new SignInResponse();
            var result = await _userRepository.GetUserByPhoneNumberAsync(phoneNumber);
            if (result == null)
            {
                response.IsNewUser = true;
                var createResult = await CreateAccountByPhoneNumberAsync(phoneNumber);
                if (!createResult.Result)
                {
                    return response;
                }
            }
            if (result != null)
            {
                response.AdditionalSecurity = _mapper.Map<ReactChat.BusinessLogicLayer.Enums.AdditionalSecurity>(result.AdditionalSecurity);
                response.IsNewUser = false;
            }
            var sendResult = await _verificationCodeService.CreateAsync(new VerificationCodeModel() { PhoneNumber = phoneNumber });
            response.Result = sendResult.Result;
            response.Message = sendResult.Message;
            response.PhoneNumber = phoneNumber;
            return response;
        }

        public async Task<ResponseModel<string>> AdditionalSecurityVerificationAsync(SignInModel signInModel)
        {
            bool passwordVerified = false;
            bool pinCodeVerified = false;
            var user = await _userRepository.GetUserByPhoneNumberAsync(signInModel.PhoneNumber);
            if ((double)user.AdditionalSecurity == 1 || (double)user.AdditionalSecurity == 3)
            {
                pinCodeVerified = await VerifyPasswordAsync(user.Id, AdditionalSecurity.PinCode, signInModel.PinCode);
            }
            if ((double)user.AdditionalSecurity == 2 || (double)user.AdditionalSecurity == 3)
            {
                passwordVerified = await VerifyPasswordAsync(user.Id, AdditionalSecurity.Password, signInModel.Password);
            }
            if ((double)user.AdditionalSecurity == 3)
            {
                return passwordVerified&&pinCodeVerified == true ? new GetResponse<string>("").GetSuccessResponse(""):new GetResponse<string>("").GetErrorResponse("Wrong additional security data");
            }
            return passwordVerified||pinCodeVerified == true ? new GetResponse<string>("").GetSuccessResponse("") : new GetResponse<string>("").GetErrorResponse("Wrong additional security data");
        }

        public async Task<ResponseModel<List<string>>> CreateAccountByPhoneNumberAsync(string phoneNumber)
        {
            var signInModel = new SignInModel
            {
                PhoneNumber = phoneNumber,
                UserName = new Guid().ToString()
            };
            var result = await _userRepository.CreateAsync(_mapper.Map<ApplicationUser>(signInModel));
            if (result.Count == 0)
            {
                return new GetResponse<List<string>>(null).GetSuccessResponse();
            }
            return new GetResponse<List<string>>(result).GetSuccessResponse();
        }

        public async Task<ResponseModel<List<string>>> CreateAccountAsync(SignInModel signInModel)
        {
            var result = await _userRepository.CreateAsync(_mapper.Map<ApplicationUser>(signInModel));
            if (result.Count == 0)
            {
                return new GetResponse<List<string>>(null).GetSuccessResponse(null);
            }
            return new GetResponse<List<string>>(null).GetErrorResponse(result.ToString());
        }

        private async Task<bool> VerifyPasswordAsync(string userId, AdditionalSecurity additionalSecurity, string password)
        {
            var securityType = _mapper.Map<ReactChat.DataAccessLayer.Entities.Enums.AdditionalSecurity>(additionalSecurity);
            var hashPassword = await _userRepository.GetPasswordHashAsync(userId, securityType);
            return PasswordHasher.Verify(hashPassword, password);
        }

        private async Task<bool> ChangePasswordAsync(UserModel userModel, AdditionalSecurity additionalSecurity, string password)
        {
            var securityType = _mapper.Map<ReactChat.DataAccessLayer.Entities.Enums.AdditionalSecurity>(additionalSecurity);
            var passwordHash = PasswordHasher.Hash(password);
            return await _userRepository.AddNewPasswordAsync(_mapper.Map<ApplicationUser>(userModel), securityType, passwordHash);
        }

    }
}

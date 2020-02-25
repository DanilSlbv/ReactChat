using AutoMapper;
using ReactChat.BusinessLogicLayer.Helpers;
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
    public class VerificationCodeService : IVerificationCodeService
    {
        private readonly IVerificationCodeRepository _verificationCodeRepository;
        private readonly IApplicationUserRepository _applicationUserRepository;
        private readonly IMapper _mapper;

        public VerificationCodeService(IVerificationCodeRepository verificationCodeRepository,
                                       IApplicationUserRepository applicationUserRepository,
                                       IMapper mapper)
        {
            _verificationCodeRepository = verificationCodeRepository;
            _applicationUserRepository = applicationUserRepository;
            _mapper = mapper;
        }

        public async Task<ResponseModel<string>> CreateAsync(VerificationCodeModel verificationCode)
        {
            var removeResult = await RemoveAllCodesByPhoneNumberAsync(verificationCode.PhoneNumber);
            if (string.IsNullOrWhiteSpace(verificationCode.UserId))
            {
                var user = await _applicationUserRepository.GetUserByPhoneNumberAsync(verificationCode.PhoneNumber);
                if (user == null)
                {
                    return new GetResponse<string>("").GetErrorResponse("Unable to find such account");
                }
                verificationCode.UserId = user.Id;
            }
            verificationCode.Code = new Helpers.PasswordGenerate().GeneratePassword();
            return await SendVerificationCodeAsync(verificationCode);

        }

        public async Task<ResponseModel<VerificationCodeModel>> GetByUserIdAsync(string userId)
        {
            var result = await _verificationCodeRepository.GetById(userId);
            return new GetResponse<VerificationCodeModel>(_mapper.Map<VerificationCodeModel>(result)).GetSuccessResponse("");
        }

        public async Task<bool> CheckIfExpiredAsync(string userId)
        {
            var result = await _verificationCodeRepository.CheckExpireAsync(userId);
            return result;
        }

        public async Task<bool> ConfirmCodeAsync(SignInModel signInModel)
        {
            var result = await _verificationCodeRepository.CheckCodeAndConfirmAsync(signInModel.PhoneNumber, signInModel.VerificationCode);
            return result;
        }

        public async Task<bool> RemoveByPhoneNumberAsync(string phoneNumber)
        {
            var result = await _verificationCodeRepository.RemoveCodeByPhoneNumberAsync(phoneNumber);
            return result;
        }

        private async Task<bool> RemoveAllCodesByPhoneNumberAsync(string phoneNumber)
        {
            return await _verificationCodeRepository.RemoveAllCodesByPhoneNumberAsync(phoneNumber);
        }

        private async Task<ResponseModel<string>> SendVerificationCodeAsync(VerificationCodeModel verificationCode)
        {
            var result = await _verificationCodeRepository.CreateAsync(_mapper.Map<VerificationCode>(verificationCode));
            if (!result)
            {
                return new GetResponse<string>("").GetErrorResponse("Error while sending code");
            }
            var sendResult = await new TwilioHelper().SendMessage(verificationCode.PhoneNumber, verificationCode.Code);
            if (string.IsNullOrEmpty(sendResult))
            {
                return new GetResponse<string>(verificationCode.UserId).GetSuccessResponse("");
            }
            return new GetResponse<string>("").GetErrorResponse("Error while sending code");
        }
    }
}

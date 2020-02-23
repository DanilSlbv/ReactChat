using ReactChat.BusinessLogicLayer.Helpers;
using ReactChat.BusinessLogicLayer.Helpers.Mapper;
using ReactChat.BusinessLogicLayer.Models;
using ReactChat.BusinessLogicLayer.Services.Interfaces;
using ReactChat.DataAccessLayer.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ReactChat.BusinessLogicLayer.Services
{
    public class VerificationCodeService:IVerificationCodeService
    {
        private readonly IVerificationCodeRepository _verificationCodeRepository;
        private readonly IApplicationUserRepository _applicationUserRepository;
        public VerificationCodeService(IVerificationCodeRepository verificationCodeRepository, IApplicationUserRepository applicationUserRepository)
        {
            _verificationCodeRepository = verificationCodeRepository;
            _applicationUserRepository = applicationUserRepository;
        }

        public async Task<ResponseModel<string>>CreateAsync(VerificationCodeModel verificationCode)
        {
            if (string.IsNullOrWhiteSpace(verificationCode.UserId))
            {
                var user = await _applicationUserRepository.GetUserByPhoneNumberAsync(verificationCode.PhoneNumber);
                if (user == null)
                {
                    return new GetResponse<string>("").GetErrorResponse("Unable to find such account");
                }
                verificationCode.UserId = user.Id;
            }
            verificationCode.Code = new PasswordHelper().GeneratePassword();
            var result = await _verificationCodeRepository.CreateAsync(MapToVerificationCode.MapToVerficationCodeToCreate(verificationCode));
            if (!result)
            {
                return new GetResponse<string>("").GetErrorResponse("Error while sending code");
            }
            var sendResult = await new TwilioHelper().SendMessage(verificationCode.PhoneNumber, verificationCode.Code);
            if (string.IsNullOrEmpty(sendResult))
            {
                return new GetResponse<string>(verificationCode.UserId).GetSuccessResponse("");
            }
            var removeResult = await RemoveByPhoneNumber(verificationCode.PhoneNumber);
            if (!removeResult)
            {
                return new GetResponse<string>("").GetErrorResponse("Please press resend");
            }
            return new GetResponse<string>("").GetErrorResponse("Error while sending code");
        }

        public async Task<ResponseModel<VerificationCodeModel>>GetByUserId(string userId)
        {
            var result = await _verificationCodeRepository.GetById(userId);
            return new GetResponse<VerificationCodeModel>(MapToVerificationCode.MapToVerificationCodeModel(result)).GetSuccessResponse("");
        }

        public async Task<bool> CheckIfExpired(string userId)
        {
            var result = await _verificationCodeRepository.CheckExpire(userId);
            return result;
        }

        public async Task<bool> ConfirmCode(VerificationCodeModel verificationCode)
        {
            var result = await _verificationCodeRepository.CheckCodeAndConfirm(MapToVerificationCode.MapToVerificationCodeEntity(verificationCode));
            return result;
        }

        public async Task<bool> RemoveByPhoneNumber(string phoneNumber)
        {
            var result = await _verificationCodeRepository.RemoveCodeByPhoneNumber(phoneNumber);
            return result;
        }
        
    }
}

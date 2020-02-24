using AutoMapper;
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

        public async Task<ResponseModel<string>> CheckIfUserExist(string phoneNumber)
        {
            var result = await _userRepository.GetUserByPhoneNumberAsync(phoneNumber);
            if (result == null)
            {
                var createResult = await CreateAccountByPhoneNumber(phoneNumber);
                if (!createResult.Result)
                {
                    return new GetResponse<string>("").GetErrorResponse(createResult.Message.ToString());
                }
            }
            return await _verificationCodeService.CreateAsync(new VerificationCodeModel() { PhoneNumber = phoneNumber });
        }

        public async Task<ResponseModel<List<string>>> CreateAccountByPhoneNumber(string phoneNumber)
        {
            var signUpModel = new SignUpModel
            {
                PhoneNumber = phoneNumber,
                UserName = new Guid().ToString()
            };
            var result = await _userRepository.CreateAsync(MapApplicationUser.MapFromSignUpModel(signUpModel));
            if (result.Count == 0)
            {
                return new GetResponse<List<string>>(null).GetSuccessResponse();
            }
            return new GetResponse<List<string>>(result).GetSuccessResponse();
        }

        public async Task<ResponseModel<List<string>>> CreateAccountAsync(SignUpModel signUpModel)
        {
            var result = await _userRepository.CreateAsync(MapApplicationUser.MapFromSignUpModel(signUpModel));
            if (result.Count == 0)
            {
                return new GetResponse<List<string>>(null).GetSuccessResponse(null);
            }
            return new GetResponse<List<string>>(null).GetErrorResponse(result.ToString());
        }



    }
}

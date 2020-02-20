using ReactChat.BusinessLogicLayer.Helpers;
using ReactChat.BusinessLogicLayer.Models;
using ReactChat.BusinessLogicLayer.Services.Interfaces;
using ReactChat.DataAccessLayer.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ReactChat.BusinessLogicLayer.Services
{
    public class MemberService:IMemberService
    {

        private readonly IMemberRepository _memberRepository;
        public MemberService(IMemberRepository memberRepository)
        {
            _memberRepository = memberRepository;
        }

        public async Task<ResponseModel<string>> CreateAsync(MemberModel memberModel)
        {
            var result = true; //await _memberRepository.CreateAsync();
            if (result) {
                return new GetResponse<string>("").GetSuccessResponse();
            }
            return new GetResponse<string>("").GetErrorResponse("");
        }
    }
}

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
    public class ChatService:IChatService
    {
        private readonly IChatRepository _chatRepository;
        private readonly IMemberRepository _memberRepository;
        private readonly IMapper _mapper;

        public ChatService(IChatRepository chatRepository,
                           IMemberRepository memberRepository,
                           IMapper mapper)
        {
            _chatRepository = chatRepository;
            _memberRepository = memberRepository;
            _mapper = mapper;
        }

        public async Task<ResponseModel<string>> AddAsync(ChatModel chatModel)
        {
            if (await _chatRepository.CreateAsync(_mapper.Map<Chat>(chatModel)))
            {
                return new GetResponse<string>("").GetSuccessResponse();
            }
            return new GetResponse<string>("").GetErrorResponse("Error when try to create.");
        }

        public async Task<ResponseModel<List<ChatModel>>> GetUserSavedChats(string userId)
        {
            var result = new List<ChatModel>();
            var chats = await _memberRepository.GetMySavedChats(userId);
            result.AddRange(_mapper.Map<List<ChatModel>>(chats));
            return new GetResponse<List<ChatModel>>(result).GetSuccessResponse("");
        }
    }
}

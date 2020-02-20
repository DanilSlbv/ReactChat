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
    public class ChatService:IChatService
    {
        private readonly IChatRepository _chatRepository;

        public ChatService(IChatRepository chatRepository)
        {
            _chatRepository = chatRepository;
        }

        public async Task<ResponseModel<string>> AddAsync(ChatModel chatModel)
        {
            if(await _chatRepository.CreateAsync(MapToChat.MapToChatEntity(chatModel)))
            {
                return new GetResponse<string>("").GetSuccessResponse();
            }
            return new GetResponse<string>("").GetErrorResponse("Error when try to create.");
        }
    }
}

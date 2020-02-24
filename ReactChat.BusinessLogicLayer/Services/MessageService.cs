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
    public class MessageService:IMessageService
    {
        private readonly IMessageRepository _messageRepository;
        private readonly IMapper _mapper;

        public MessageService(IMessageRepository messageRepository,
                              IMapper mapper)
        {
            _messageRepository = messageRepository;
            _mapper = mapper;
        }

        public async Task<ResponseModel<string>>CreateAsync(MessageModel messageModel)
        {
            var result = await _messageRepository.CreateAsync(_mapper.Map<Message>(messageModel));
            if (result)
            {
                return new GetResponse<string>("").GetSuccessResponse();
            }
            return new GetResponse<string>("").GetErrorResponse("Error, when try to create");
        }

    }
}

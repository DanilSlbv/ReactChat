using ReactChat.BusinessLogicLayer.Enums;
using ReactChat.BusinessLogicLayer.Models;
using ReactChat.DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReactChat.BusinessLogicLayer.Helpers.Mapper
{
    public static class MapToChat
    {
        public static ChatModel MapToChatModel(Chat chat)
        {
            return new ChatModel
            {
                Id = chat.Id,
                Title = chat.Title,
                CreatedById = chat.CreatorId,
                CreatedOn = chat.CreateOn,
                ChatType = (ChatTypes)chat.ChatType
            };
        }
        public static Chat MapToChatEntity(ChatModel chat)
        {
            return new Chat
            {
                Id = chat.Id,
                Title = chat.Title,
                CreatorId= chat.CreatedById,
                ChatType = (ReactChat.DataAccessLayer.Entities.Enums.ChatTypes)chat.ChatType
            };
        }
    }
}

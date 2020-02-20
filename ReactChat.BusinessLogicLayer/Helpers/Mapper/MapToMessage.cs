using ReactChat.BusinessLogicLayer.Models;
using ReactChat.DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReactChat.BusinessLogicLayer.Helpers.Mapper
{
    public static class MapToMessage
    {
        public static MessageModel MapToMessageModel(Message message)
        {
            return new MessageModel
            {
                Id = message.Id,
                UserId = message.UserId,
                UserName = message.User.UserName,
                Text = message.Text,
                ChatId = message.ChatId,
                CreatedOn = message.CreateOn,
                ModifiedOn = message.ModifiedOn
            };
        }

        public static Message MapToMessageEntity(MessageModel message)
        {
            return new Message
            {
                Id = message.Id,
                ChatId = message.ChatId,
                Text = message.Text,
                UserId = message.UserId
            };
        }
    }
}

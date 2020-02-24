using ReactChat.DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ReactChat.DataAccessLayer.Repositories.Interfaces
{
    public interface IMessageRepository:IBaseRepository<Message>
    {
        Task<List<Message>> GetMessagesInChat(string chatId);
    }
}

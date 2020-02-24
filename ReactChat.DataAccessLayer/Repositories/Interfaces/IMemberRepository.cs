using ReactChat.DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ReactChat.DataAccessLayer.Repositories.Interfaces
{
    public interface IMemberRepository:IBaseRepository<Member>
    {
        Task<List<Chat>> GetMySavedChats(string userId);
        Task<List<Member>> GetChatMembers(string chatId);
    }
}

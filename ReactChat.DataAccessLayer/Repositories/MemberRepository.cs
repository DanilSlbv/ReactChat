using Microsoft.EntityFrameworkCore;
using ReactChat.DataAccessLayer.Entities;
using ReactChat.DataAccessLayer.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReactChat.DataAccessLayer.Repositories
{
    public class MemberRepository:BaseRepository<Member>,IMemberRepository
    {
        private readonly ApplicationContext _context;
        public MemberRepository(ApplicationContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Chat>> GetMySavedChats(string userId)
        {
            var result = await _context.Members.Where(x => x.Deleted == false && x.UserId == userId).Select(x => x.Chat).ToListAsync();
            return result;
        }
        
        public async Task<List<Member>> GetChatMembers(string chatId)
        {
            var result = await _context.Members.Where(x => x.Deleted == false && x.ChatId==chatId).ToListAsync();
            return result;
        }

    }
}

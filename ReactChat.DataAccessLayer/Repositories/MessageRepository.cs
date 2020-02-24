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
    public class MessageRepository:BaseRepository<Message>,IMessageRepository
    {
        private readonly ApplicationContext _context;
        public MessageRepository(ApplicationContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Message>>GetMessagesInChat(string chatId)
        {
            var result = await _context.Messages.Where(x => x.ChatId == chatId && x.Deleted == false).ToListAsync();
            return result;
        }
       
    }
}

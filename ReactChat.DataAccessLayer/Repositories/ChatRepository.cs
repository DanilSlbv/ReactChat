using ReactChat.DataAccessLayer.Entities;
using ReactChat.DataAccessLayer.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ReactChat.DataAccessLayer.Repositories
{
    public class ChatRepository:BaseRepository<Chat>,IChatRepository
    {
        private readonly ApplicationContext _context;
        public ChatRepository(ApplicationContext context):base(context)
        {
            _context = context;
        }
        
    }
}

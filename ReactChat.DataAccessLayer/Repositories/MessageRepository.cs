using ReactChat.DataAccessLayer.Entities;
using ReactChat.DataAccessLayer.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReactChat.DataAccessLayer.Repositories
{
    public class MessageRepository:BaseRepository<Message>,IMessageRepository
    {
        private readonly ApplicationContext _context;
        public MessageRepository(ApplicationContext context) : base(context)
        {

        }
    }
}

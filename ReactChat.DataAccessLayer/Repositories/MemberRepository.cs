using ReactChat.DataAccessLayer.Entities;
using ReactChat.DataAccessLayer.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReactChat.DataAccessLayer.Repositories
{
    public class MemberRepository:BaseRepository<Member>,IMemberRepository
    {
        private readonly ApplicationContext _context;
        public MemberRepository(ApplicationContext context) : base(context)
        {

        }
    }
}

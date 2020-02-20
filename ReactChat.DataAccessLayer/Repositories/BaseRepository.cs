using Microsoft.EntityFrameworkCore;
using ReactChat.DataAccessLayer.Entities;
using ReactChat.DataAccessLayer.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ReactChat.DataAccessLayer.Repositories
{
    public class BaseRepository<TEntity>:IBaseRepository<TEntity> where TEntity : class
    {
        public readonly ApplicationContext _context;
        public readonly DbSet<TEntity> _dbSet;
        public BaseRepository(ApplicationContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        public async Task<TEntity> GetById(string id) => await _dbSet.FindAsync(id);

        public async Task<bool> CreateAsync(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
            if (await _context.SaveChangesAsync() > 0)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> EditAsync(TEntity entity)
        {
            _context.Update(entity);
            if (await _context.SaveChangesAsync() > 0)
            {
                return true;
            }
            return false;
        }
    }
}

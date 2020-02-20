using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ReactChat.DataAccessLayer.Repositories.Interfaces
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        Task<TEntity> GetById(string id);
        Task<bool> CreateAsync(TEntity entity);
        Task<bool> EditAsync(TEntity entity);
    }
}

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using DatingApp.Model.Models;

namespace DatingApp.Model.Repository.IRepository
{
    public interface IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        Task<IEnumerable<TEntity>> GetAll();
        Task<IEnumerable<TEntity>> GetByExpression(Expression<Func<TEntity, bool>> expression);
        Task<TEntity> Get(int id);
        Task<TEntity> Add(TEntity entity);
        Task<bool> Delete(TEntity entity);
        bool Delete(int id);
        TEntity Update(TEntity entity);
        Task SaveChanges();
    }
}

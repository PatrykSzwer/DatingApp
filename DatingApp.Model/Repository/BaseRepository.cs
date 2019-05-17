using DatingApp.Model.Data;
using DatingApp.Model.Models;
using DatingApp.Model.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DatingApp.Model.Repository
{
    // TODO: Try to add UnitOfWork and implement pure generic repository again.
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly DataContext _context;

        public BaseRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await _context.Set<TEntity>().ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> GetByExpression(Expression<Func<TEntity, bool>> expression)
        {
            return await this._context.Set<TEntity>().Where(expression).ToListAsync();
        }

        public async Task<TEntity> Get(int id)
        {
            return await this._context.Set<TEntity>().FirstOrDefaultAsync(entity => entity.Id == id);
        }

        public async Task<TEntity> Add(TEntity entity)
        {
            entity.Created = DateTime.Now;
            return (await this._context.Set<TEntity>().AddAsync(entity)).Entity;
        }


        public async Task<bool> Delete(TEntity entity)
        {
            if (await this.Get(entity.Id) == null)
            {
                return false;
            }

            this._context.Set<TEntity>().Remove(entity);

            return true;
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public TEntity Update(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}

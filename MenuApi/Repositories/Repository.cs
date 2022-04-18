using MenuApi.Data;
using MenuApi.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace MenuApi.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        private Context _context;

        public Repository(Context context)
        {
            _context = context;
        }

        public void Delete(int id)
        {
            if (id > 0)
            {
                var entity = GetById(id);
                _context.Set<TEntity>().Remove(entity);
                _context.SaveChanges();
            }
        }

        public void Delete(TEntity entity)
        {
            if (entity != null)
            {
                _context.Set<TEntity>().Remove(entity);
                _context.SaveChanges();
            }
        }

        public void DeleteBy(Expression<Func<TEntity, bool>> filter = null)
        {
            var entityList = _context.Set<TEntity>().Where(filter).ToList();
            DeleteRange(entityList);
        }

        public void DeleteByIds(int[] entityIds)
        {
            var entityList = _context.Set<TEntity>().Where(w => entityIds.Contains(w.Id)).ToList();
            DeleteRange(entityList);
        }

        public void DeleteRange(List<TEntity> entities)
        {
            _context.Set<TEntity>().RemoveRange(entities);
            _context.SaveChanges();
        }

        public List<TEntity> GetAll()
        {
            return _context.Set<TEntity>().ToList();
        }

        public TEntity GetById(int id)
        {
            return _context.Set<TEntity>().Find(id);
        }

        public void Insert(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
            _context.SaveChanges();
        }

        public void Update(TEntity entity)
        {
            _context.Entry<TEntity>(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}

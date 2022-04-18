using MenuApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace MenuApi.Repositories
{
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        List<TEntity> GetAll();
        TEntity GetById(int id);
        void Insert(TEntity entity);
        void Update(TEntity entity);
        void Delete(int id);
        void Delete(TEntity entity);
        void DeleteRange(List<TEntity> entities);
        void DeleteByIds(int[] entityIds);
        void DeleteBy(Expression<Func<TEntity, bool>> filter = null);
    }
}

using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess
{
    public interface IEntityRepository<T> where T : class, IEntity, new()
    {
        T Get(Expression<Func<T, bool>> predict);
        IList<T> GetList(Expression<Func<T, bool>>? predic = null);
        T Add(T entity);    
        void Delete(T entity);
        void Update(T entity);
    }
}

using DevIO.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DevIO.Business.Intefaces
{
    public interface IRepositoryTeste<TEntity> : IDisposable where TEntity : Entity
    {
        void Add(TEntity obj);
        TEntity GetById(Guid id);
        IEnumerable<TEntity> GetAll();
        void Update(TEntity obj);
        void Remove(Guid id);
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        int SaveChanges();
    }
}

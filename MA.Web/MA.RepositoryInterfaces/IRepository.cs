using System;
using System.Collections.Generic;
using MA.DomainEntities;

namespace MA.RepositoryInterfaces
{
    public interface IRepository<T> : IReadonlyRepository<T> where T : BaseEntity
    {
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}

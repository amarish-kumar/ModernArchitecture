using System;
using System.Collections.Generic;
using MA.DomainEntities;

namespace MA.RepositoryInterfaces
{
    public interface IReadonlyRepository<out T> where T : BaseEntity
    {
        IEnumerable<T> GetAll();
        T Get(Guid id);
    }
}

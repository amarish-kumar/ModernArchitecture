using System;
using System.Collections.Generic;
using System.Linq;
using MA.DomainEntities;
using MA.Repositories.EF;
using MA.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;

namespace MA.Repositories.Stores
{
    public class GenericRepository<T> : IRepository<T> where T : BaseEntity
    {
        protected readonly ApplicationContext Context;
        protected readonly DbSet<T> Entities;

        public GenericRepository(ApplicationContext context)
        {
            Context = context;
            Entities = context.Set<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return Entities.AsEnumerable();
        }

        public T Get(Guid id)
        {
            return Entities.SingleOrDefault(s => s.ID == id);
        }
        public void Insert(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            Entities.Add(entity);
        }

        public void Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
        }

        public void Delete(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            Entities.Remove(entity);
        }
    }
}

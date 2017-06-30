using System;
using System.Collections.Generic;
using System.Linq;
using MA.DomainEntities;
using MA.RepositoryInterfaces;

namespace MA.Repositories.Stores
{
    public class InMemoryUserRepository : IUserRepository
    {
        private static List<User> _users;
        public InMemoryUserRepository()
        {
            _users = new List<User>();
        }

        public IEnumerable<User> GetActiveUsers()
        {
           return _users.Where(x => x.IsActive);
        }

        public IEnumerable<User> GetAll()
        {
            return _users;
        }

        public User Get(Guid id)
        {
            return _users.FirstOrDefault(x => x.ID == id);
        }

        public void Insert(User entity)
        {
            _users.Add(entity);
        }

        public void Update(User entity)
        {
            var user = Get(entity.ID);

            user.Username = entity.Username;
            user.IsActive = entity.IsActive;
        }

        public void Delete(User entity)
        {
            _users.Remove(entity);
        }
    }
}

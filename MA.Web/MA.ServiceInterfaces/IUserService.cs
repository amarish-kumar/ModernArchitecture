using System;
using System.Collections.Generic;
using MA.DomainEntities;

namespace MA.ServiceInterfaces
{
    public interface IUserService
    {
        IEnumerable<User> GetUsers(bool onlyActive);
        User GetUser(Guid id);
        void InsertUser(User user);
        void UpdateUser(User user);
        void DeleteUser(Guid id);
    }
}

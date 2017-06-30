using System.Collections.Generic;
using MA.DomainEntities;

namespace MA.RepositoryInterfaces
{
    public interface IUserRepository : IRepository<User>
    {
        IEnumerable<User> GetActiveUsers();
    }
}

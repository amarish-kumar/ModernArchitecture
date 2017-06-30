using System.Collections.Generic;
using System.Linq;
using MA.DomainEntities;
using MA.Repositories.EF;
using MA.RepositoryInterfaces;

namespace MA.Repositories.Stores
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(ApplicationContext context) : base(context)
        {
        }

        public IEnumerable<User> GetActiveUsers()
        {
            return Entities.Where(x => x.IsActive).AsEnumerable();
        }
    }
}

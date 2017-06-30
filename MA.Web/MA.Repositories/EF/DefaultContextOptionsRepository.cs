using MA.DomainEntities;
using MA.RepositoryInterfaces;

namespace MA.Repositories.EF
{
    public class DefaultContextOptionsRepository : IContextOptionsRepository
    {
        ContextOptions _options;
        public DefaultContextOptionsRepository(ContextOptions options)
        {
            _options = options;
        }

        public ContextOptions GetOptions()
        {
            return _options;
        }
    }
}

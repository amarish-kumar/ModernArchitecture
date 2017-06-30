using MA.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;

namespace MA.Repositories.EF
{
    public class DataProcessor : IDataContext
    {
        private readonly DbContext _context;
        public DataProcessor(ApplicationContext context)
        {
            _context = context;
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}

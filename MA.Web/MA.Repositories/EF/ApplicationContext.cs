using MA.DomainEntities;
using MA.Repositories.EF.Mappings;
using MA.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;

namespace MA.Repositories.EF
{
    public class ApplicationContext : DbContext
    {
        ContextOptions _options;

        public ApplicationContext(DbContextOptions<ApplicationContext> options, IContextOptionsRepository contextOptionsRepository) : base(options)
        {
            _options = contextOptionsRepository.GetOptions();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            new UserMap(modelBuilder.Entity<User>());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
    }
}

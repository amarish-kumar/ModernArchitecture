using System.Configuration;
using MA.DI;
using MA.ServiceInterfaces;
using Microsoft.Extensions.DependencyInjection;
using MA.RepositoryInterfaces;
using MA.Repositories.EF;
using System;

namespace MA.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var services = new ServiceCollection();

            services.AddTransient<IContextOptionsRepository, DefaultContextOptionsRepository>(x => new DefaultContextOptionsRepository(new DomainEntities.ContextOptions { TenantId = Guid.Empty }));

            var container = DependencyBuilder.GetServiceProvider(services,
                new DependencyBuilderOptions{ ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString });

            var userService = container.GetService<IUserService>();

            foreach (var user in userService.GetUsers(false))
            {
                System.Console.WriteLine(user.Username);
            }

            System.Console.Read();
        }
    }
}

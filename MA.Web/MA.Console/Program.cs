using System.Configuration;
using MA.DI;
using MA.ServiceInterfaces;
using Microsoft.Extensions.DependencyInjection;

namespace MA.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = DependencyBuilder.GetServiceProvider(new ServiceCollection(),
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

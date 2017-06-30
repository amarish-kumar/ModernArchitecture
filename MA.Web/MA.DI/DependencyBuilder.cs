using System;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using MA.Repositories.EF;
using MA.Repositories.Stores;
using MA.RepositoryInterfaces;
using MA.ServiceInterfaces;
using MA.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

namespace MA.DI
{
    public static class DependencyBuilder
    {
        public static IServiceProvider GetServiceProvider(IServiceCollection services, DependencyBuilderOptions config)
        {
            var builder = new ContainerBuilder();

            //Common
            services.AddSingleton<DependencyBuilderOptions>(config);
            services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(config.ConnectionString));
            services.AddScoped<IDataContext, DataProcessor>();

            //Repositories
            services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));
            services.AddTransient<IUserService, UserService>();

            //Services
            services.AddTransient<IUserRepository, UserRepository>();

            builder.Populate(services);

            var container = builder.Build();
            return container.Resolve<IServiceProvider>();
        }
    }

    public class DependencyBuilderOptions
    {
        public string ConnectionString { get; set; }
    }
}

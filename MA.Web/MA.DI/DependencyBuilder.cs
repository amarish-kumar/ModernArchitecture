using System;
using System.Data;
using System.Data.SqlClient;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using MA.DomainEntities;
using MA.Repositories.EF;
using MA.Repositories.Stores;
using MA.RepositoryInterfaces;
using MA.ServiceInterfaces;
using MA.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

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
            services.AddScoped<IDbConnection, SqlConnection>(x => new SqlConnection(config.ConnectionString));

            //Repositories
            services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IReadonlyRepository<User>, UserReadonlyRepository>();

            //Services
            services.AddTransient<IUserService, UserService>();

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

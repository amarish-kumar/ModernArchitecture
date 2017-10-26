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
using Serilog;
using Serilog.Events;
using Serilog.Formatting.Json;
using Serilog.Sinks.MSSqlServer;
using Serilog.Sinks.RollingFile;

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
            services.AddSingleton<ILoggerService, LoggerService>();

            //Repositories
            services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IReadonlyRepository<User>, UserReadonlyRepository>();

            //Services
            services.AddTransient<IUserService, UserService>();

            builder.Populate(services);

            builder.Register(c => SerilogConfig.CreateLogger(config))
                   .As<ILogger>()
                   .SingleInstance();

            var container = builder.Build();
            return container.Resolve<IServiceProvider>();
        }
    }

    public class DependencyBuilderOptions
    {
        public string ConnectionString { get; set; }
    }

    public class SerilogConfig
    {
        public static ILogger CreateLogger(DependencyBuilderOptions con)
        {
            var columnOptions = new ColumnOptions();
            columnOptions.Store.Remove(StandardColumn.Properties);
            columnOptions.Store.Add(StandardColumn.LogEvent);

            var config = new LoggerConfiguration().
                MinimumLevel.Debug()
                .WriteTo.MSSqlServer(con.ConnectionString, "Logs", columnOptions: columnOptions, restrictedToMinimumLevel:LogEventLevel.Error)
                .WriteTo.LiterateConsole(LogEventLevel.Debug)
                .WriteTo.Sink(new RollingFileSink("log-debug-{Date}.json", new JsonFormatter(renderMessage: true), null, null), LogEventLevel.Debug)
                .WriteTo.RollingFile("log-debug-{Date}.log", LogEventLevel.Debug)
                .WriteTo.Sink(new RollingFileSink("log-{Date}.json", new JsonFormatter(renderMessage: true), null, null), LogEventLevel.Warning);

            InitialiseGlobalContext(config);

            return config.CreateLogger();
        }

        public static LoggerConfiguration InitialiseGlobalContext(LoggerConfiguration configuration)
        {
            return configuration.Enrich.WithMachineName()
                                .Enrich.WithProperty("ApplicationName", typeof(SerilogConfig).Assembly.GetName().Name)
                                .Enrich.WithProperty("UserName", Environment.UserName)
                                .Enrich.WithProperty("AppDomain", AppDomain.CurrentDomain)
                                .Enrich.WithProperty("RuntimeVersion", Environment.Version)
                                // this ensures that calls to LogContext.PushProperty will cause the logger to be enriched
                                .Enrich.FromLogContext();
        }
    }
}

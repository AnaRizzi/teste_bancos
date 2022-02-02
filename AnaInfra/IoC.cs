using AnaDomain.Interfaces;
using AnaDomain.Service;
using AnaInfra.EntityFramework;
using AnaInfra.Mongo;
using AnaInfra.Postgre;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AnaInfra
{
    public static class IoC
    {
		public static IServiceCollection ConfigureContainer(this IServiceCollection services, IConfiguration configuration)
		{
			RegisterConfiguration(services, configuration);
			RegisterServices(services);
			RegisterRepositories(services, configuration);
			return services;
		}

        public static void RegisterConfiguration(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped(c => new ClienteContext(configuration.GetConnectionString("MySql")));
        }

        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<IClienteService, ClienteService>();
        }

        public static void RegisterRepositories(IServiceCollection services, IConfiguration configuration)
        {
            var config = configuration.GetSection("MongoConfig").Get<MongoConfig>();

            services.AddScoped<IClienteDAO, ClienteDAOEntity>();
            services.AddScoped<ILogsDAO, LogsDAO>(c => new LogsDAO(configuration.GetConnectionString("Postgre")));
            services.AddScoped<IMongoDb, MongoDb>(c => new MongoDb(configuration.GetConnectionString("MongoDb"), config));
        }
    }
}

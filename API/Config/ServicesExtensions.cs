using Core.Commands;
using Core.Interfaces;
using Core.Queries;
using Data.Repositories;

namespace API.Config
{
    public static class ServicesExtensions
    {
        /// <summary>
        /// Method to inyect dependencies that will use in services methods
        /// </summary>
        /// <param name="services"></param>
        public static void AddReadWriteScopes(this IServiceCollection services)
        {
            services.AddScoped<IUserQueries, UserQueries>();
            services.AddScoped<IUserCommands, UserCommands>();
        }

        /// <summary>
        /// Method to inyect dependencies that will use in reposioties methods
        /// </summary>
        /// <param name="services"></param>
        public static void AddRepositoriesScopes(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped(typeof(IGenericRepository<,>), typeof(GenericRepository<,>));
        }

        /// <summary>
        /// Method to inyect trasients dependencies 
        /// </summary>
        /// <param name="services"></param>
        public static void AddTrasients(this IServiceCollection services)
        {
            services.AddTransient<IUnitOfWork, UnitOfWork>();
        }

        /// <summary>
        /// Method to inyect database services
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        public static void AddDatabaseServices(this IServiceCollection services, IConfiguration configuration)
        {

        }

        /// <summary>
        /// Method to inyect JWT services
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        public static void AddJWTServices(this IServiceCollection services, IConfiguration configuration)
        {

        }
        
        /// <summary>
        /// Method to inyect Automapper services
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        public static void AddAutomapperServices(this IServiceCollection services)
        {

        }
    }
}

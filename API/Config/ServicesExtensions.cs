using System.Diagnostics;

using Microsoft.EntityFrameworkCore;

using Data.AppDbContext;
using Data.Repositories;
using Core.Interfaces;

namespace API.Config
{
    public static class ServicesExtensions
    {
        /// <summary>
        /// Method to inyect dependencies that will use in reposioties methods
        /// </summary>
        /// <param name="services"></param>
        public static void AddRepositoriesScopes(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
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
            services.AddDbContext<ApplicationDbContext>(
                o =>
                {
                    o.UseInMemoryDatabase(nameof(ApplicationDbContext))
                        .LogTo((msg) => Debug.WriteLine(msg));
                });
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
            services.AddAutoMapper(mapper => mapper.AddMaps(nameof(Core)));
        }
    }
}

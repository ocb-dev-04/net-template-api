using System.Diagnostics;

using Microsoft.EntityFrameworkCore;

using Data.AppDbContext;
using Data.Repositories;
using Core.Interfaces;
using AutoFixture;
using Core.Entities;
using Microsoft.AspNetCore.Identity;

namespace API.Config
{
    public static class ServicesExtensions
    {
        private const string DevString = "DevString";
        private const string ProdString = "ProdString";

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
        public static void AddDatabaseServices(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddDbContext<ApplicationDbContext>(
                o =>
                {
#if DEBUG
                    o.UseSqlServer(
                        Configuration.GetConnectionString(DevString),
                        providerOptions => { 
                            providerOptions.EnableRetryOnFailure();
                            providerOptions.CommandTimeout(20);
                        })
                        .LogTo((msg) => Debug.WriteLine(msg))
                        .EnableDetailedErrors(true)
                        .EnableSensitiveDataLogging(true);
#else
                    o.UseSqlServer(
                        Configuration.GetConnectionString(ProdString),
                        providerOptions => providerOptions.EnableRetryOnFailure());
#endif
                }
            );
        }

        public static void AddFakeData(this ApplicationDbContext context)
        {
            context.Database.EnsureCreated();
            context.Seed();
        }

        public static void Seed(this ApplicationDbContext context)
        {
            if (!context.User.Any())
            {
                Fixture fixture = new Fixture();
                fixture.Customize<User>(product => product.Without(p => p.Id));
                List<User> products = fixture.CreateMany<User>(100).ToList();
                context.AddRange(products);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Method to inyect JWT services
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        public static void AddJWTServices(this IServiceCollection services, IConfiguration Configuration)
        {
            //services.AddIdentity<AuthUser, IdentityRole>()
            //            .AddEntityFrameworkStores<ApplicationDbContext>()
            //            .AddDefaultTokenProviders();
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

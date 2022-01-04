﻿namespace API.Config
{
    public static class ServicesExtensions
    {
        /// <summary>
        /// Method to inyect dependencies that will use in services methods
        /// </summary>
        /// <param name="services"></param>
        public static void AddServicesScopes(this IServiceCollection services)
        {

        }

        /// <summary>
        /// Method to inyect dependencies that will use in reposioties methods
        /// </summary>
        /// <param name="services"></param>
        public static void AddRepositoriesScopes(this IServiceCollection services)
        {

        }

        /// <summary>
        /// Method to inyect trasients dependencies 
        /// </summary>
        /// <param name="services"></param>
        public static void AddTrasients(this IServiceCollection services)
        {

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
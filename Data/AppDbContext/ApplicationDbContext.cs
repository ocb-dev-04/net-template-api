using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.AppDbContext
{
    public class ApplicationDbContext : DbContext
    {
        #region Ctor

        /// <summary>
        /// AppDbContext contructor
        /// </summary>
        /// <param name="options"></param>
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        #endregion

        #region DbSets

        /// <summary>
        /// Database entity to User table
        /// </summary>
        public DbSet<User> User { get; set; }


        #endregion

        #region OnModelCreating

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // if some time need ignore this filter just add this: .IgnoreQueryFilters() to linq query
            modelBuilder.Entity<User>().HasQueryFilter(f => !f.Deleted);
        }

        #endregion
    }
}

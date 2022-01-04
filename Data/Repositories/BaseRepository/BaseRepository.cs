using Data.AppDbContext;

namespace Data.Repositories
{
    /// <summary>
    /// <see cref="BaseRepository"/> intance
    /// </summary>
    public class BaseRepository
    {
        protected readonly ApplicationDbContext _context;

        /// <summary>
        /// <see cref="BaseRepository"/> constructor
        /// </summary>
        /// <param name="context"></param>
        public BaseRepository(ApplicationDbContext context)
        {
            _context = context;
        }
    }
}

using AutoMapper;
using Data.AppDbContext;

namespace Data.Repositories
{
    /// <summary>
    /// <see cref="BaseRepository"/> intance
    /// </summary>
    public class BaseRepository : IDisposable
    {
        #region Properties

        protected readonly ApplicationDbContext _context;
        protected readonly IMapper _mapper;

        #endregion

        #region Ctor

        /// <summary>
        /// <see cref="BaseRepository"/> constructor
        /// </summary>
        /// <param name="context"></param>
        public BaseRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Virtual dispose
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            if (_context != null)
            {
                _context.Dispose();
            }
        }

        /// <summary>
        /// Dispose all memory
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
        }

        #endregion
    }
}

using Microsoft.EntityFrameworkCore;

using AutoMapper;

using Data.AppDbContext;
using Core.Interfaces;
using Core.Entities;

namespace Data.Repositories
{
    public sealed class GenericRepository<Entity> : BaseRepository, IGenericRepository<Entity> where Entity : BaseEntity
    {
        #region Properties

        private readonly DbSet<Entity> _table;

        #endregion

        #region Ctor

        public GenericRepository(ApplicationDbContext context, IMapper mapper) : base(context, mapper)
        {
            _table = context.Set<Entity>();
        }

        #endregion

        #region Read

        /// <inheritdoc/>
        public async Task<int> Count()
            => await _table.CountAsync();

        #endregion

        #region Write Actions

        /// <inheritdoc/>
        public async Task Create(Entity create)
        {
            await _table.AddAsync(create);
        }

        /// <inheritdoc/>
        public async Task Update(Entity update)
        {
            Entity finded = await _table.FindAsync(update.Id);
            if (finded == null) throw new ArgumentNullException(nameof(finded));

            _context.Entry(finded).CurrentValues.SetValues(update);
        }

        /// <inheritdoc/>
        public async Task Delete(Guid id)
        {
            Entity finded = await _table.FindAsync(id);
            if (finded == null) throw new ArgumentNullException(nameof(finded));
            finded.Deleted = true;
            _context.Entry(finded).CurrentValues.SetValues(finded);
        }

        #endregion
    }
}

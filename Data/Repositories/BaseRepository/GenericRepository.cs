using Microsoft.EntityFrameworkCore;

using Data.AppDbContext;

using Core.Interfaces.Repositories.BaseRepositories;
using Core.Entities;

namespace Data.Repositories.BaseRepository
{
    public sealed class GenericRepository<Entity> : BaseRepository, IGenericRepository<Entity> where Entity : BaseEntity
    {
        #region Properties

        private readonly DbSet<Entity> _table;

        #endregion
        
        #region Ctor

        public GenericRepository(ApplicationDbContext context):base(context)
        {
            _table = context.Set<Entity>();
        }

        #endregion

        #region Get Collections

        /// <inheritdoc/>
        public async Task<HashSet<Entity>> GetAll()
        {
            IEnumerable<Entity> list =  await _table.ToListAsync();
            return list.ToHashSet<Entity>();
        }

        /// <inheritdoc/>
        public async Task<HashSet<Entity>> GetAllDeletes()
        {
            IEnumerable<Entity> list = await _table.IgnoreQueryFilters().Where(w => w.Deleted).ToListAsync();
            return list.ToHashSet<Entity>();
        }

        #endregion

        #region Get Single

        /// <inheritdoc/>
        public async Task<Entity?> GetById(Guid id)
            => await _table.FindAsync(id);

        #endregion

        #region Write Actions

        /// <inheritdoc/>
        public async Task Create(Entity entity)
        {
            await _table.AddAsync(entity);
            // save changes is invoque in unit of work
        }

        /// <inheritdoc/>
        public async Task Update(Guid id, Entity entity)
        {
            Entity? finded = await _table.FindAsync(id);
            if(finded == null) throw new ArgumentNullException(nameof(finded));

            _context.Entry(finded).CurrentValues.SetValues(entity);
            // save changes is invoque in unit of work
        }

        /// <inheritdoc/>
        public async Task Delete(Guid id)
        {
            Entity? finded = await _table.FindAsync(id);
            if (finded == null) throw new ArgumentNullException(nameof(finded));

            _table.Remove(finded);
            // save changes is invoque in unit of work
        }

        #endregion
    }
}

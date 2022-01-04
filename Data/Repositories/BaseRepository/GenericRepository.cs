using Microsoft.EntityFrameworkCore;

using AutoMapper;

using Data.AppDbContext;
using Core.Interfaces;
using Core.Entities;
using Core.DTOs;

namespace Data.Repositories
{
    public sealed class GenericRepository<Entity, DTO> 
        : BaseRepository, IGenericRepository<Entity, DTO> 
            where Entity : BaseEntity 
            where DTO : BaseDTO
    {
        #region Properties

        private readonly DbSet<Entity> _table;

        #endregion
        
        #region Ctor

        public GenericRepository(ApplicationDbContext context, IMapper mapper):base(context, mapper)
        {
            _table = context.Set<Entity>();
        }

        #endregion

        #region Write Actions

        /// <inheritdoc/>
        public async Task Create(DTO create)
        {
            Entity mapped = _mapper.Map<Entity>(create);
            await _table.AddAsync(mapped);
            // save changes is invoque in unit of work
        }

        /// <inheritdoc/>
        public async Task Update(Guid id, DTO update)
        {
            Entity? finded = await _table.FindAsync(id);
            if(finded == null) throw new ArgumentNullException(nameof(finded));

            finded = _mapper.Map<Entity>(update);

            _context.Entry(finded).CurrentValues.SetValues(update);
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

using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Core
{
    public class BaseService<TDto, T> : IEntityBaseService<TDto> 
        where TDto: class 
        where T : class, 
        IEntityBase
    {
        protected AppDbContext _context;
        protected IMapper _mapper;

        public BaseService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TDto>> GetAllAsync() => _mapper.Map<List<TDto>>(await _context.Set<T>().ToListAsync());

        public async Task<TDto> GetByIdAsync(int id) => _mapper.Map<TDto>(await _context.Set<T>().FirstOrDefaultAsync(n => n.Id == id));

        public virtual async Task<TDto> CreateAsync(TDto entity)
        {
            var newEntity = _mapper.Map<T>(entity);
            await _context.Set<T>().AddAsync(newEntity);
            await _context.SaveChangesAsync();
            return _mapper.Map<TDto>(newEntity);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.Set<T>().AsNoTracking().FirstOrDefaultAsync(n => n.Id == id);
            if (entity == null) return false;
            EntityEntry entityEntry = _context.Entry<T>(entity);
            entityEntry.State = EntityState.Deleted;
            await _context.SaveChangesAsync();
            return true;
        }

        
        public virtual async Task<bool> UpdateAsync(int id, TDto entity)
        {
            var updatedEntity = await _context.Set<T>().AsNoTracking().FirstOrDefaultAsync(n => n.Id == id);
            if (updatedEntity == null) return false;
            EntityEntry entityEntry = _context.Entry<T>(_mapper.Map<T>(entity));
            entityEntry.State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return true;
        }
    }
}

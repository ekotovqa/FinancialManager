using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Core
{
    public class OperationService : BaseService<OperationDto, Operation>, IOperationService
    {
        public OperationService(AppDbContext context, IMapper mapper) : base(context, mapper)
        {
        }
        public override async Task<bool> UpdateAsync(int id, OperationDto entity)
        {
            if (await _context.Set<Operation>().AsNoTracking().FirstOrDefaultAsync(n => n.Id == entity.Id) == null)
            {
                return false;
            }
            if (await _context.Set<OperationType>().FirstOrDefaultAsync(n => n.Id == entity.OperationTypeId) == null)
            {
                return false;
            }
            return await base.UpdateAsync(id, entity);
        }

        public override async Task<OperationDto> CreateAsync(OperationDto entity)
        {
            if (await _context.Set<OperationType>().FirstOrDefaultAsync(n => n.Id == entity.OperationTypeId) == null)
            {
                return null;
            }
            return await base.CreateAsync(entity);
        }

        public async Task<List<OperationDto>> GetOperationsByType(bool isIncome)
        {
            return _mapper.Map<List<OperationDto>>(await _context.Set<Operation>().Where(n => n.OperationType.IsIncome == isIncome).ToListAsync());
        }
    }
}

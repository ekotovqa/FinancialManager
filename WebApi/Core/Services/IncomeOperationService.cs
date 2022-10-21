using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Core
{
    public class IncomeOperationService : BaseService<IncomeOperationDto, IncomeOperation>, IIncomeOperationService
    {
        public IncomeOperationService(AppDbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override async Task<bool> UpdateAsync(int id, IncomeOperationDto entity)
        {
            if (await _context.Set<IncomeType>().FirstOrDefaultAsync(n => n.Id == entity.IncomeTypeId) == null)
            {
                return false;
            }
            return await base.UpdateAsync(id, entity);
        }

        public override async Task<IncomeOperationDto> CreateAsync(IncomeOperationDto entity)
        {
            if (await _context.Set<IncomeType>().FirstOrDefaultAsync(n => n.Id == entity.IncomeTypeId) == null)
            {
                return null;
            }
            return await base.CreateAsync(entity);
        }
    }
}

using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Core
{
    public class ExpenseOperationService : BaseService<ExpenseOperationDto, ExpenseOperation>, IExpenseOperationService
    {
        public ExpenseOperationService(AppDbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override async Task<bool> UpdateAsync(int id, ExpenseOperationDto entity)
        {
            if (await _context.Set<IncomeType>().FirstOrDefaultAsync(n => n.Id == entity.ExpenseTypeId) == null)
            {
                return false;
            }
            return await base.UpdateAsync(id, entity);
        }

        public override async Task<ExpenseOperationDto> CreateAsync(ExpenseOperationDto entity)
        {
            if (await _context.Set<IncomeType>().FirstOrDefaultAsync(n => n.Id == entity.ExpenseTypeId) == null)
            {
                return null;
            }
            return await base.CreateAsync(entity);
        }
    }
}

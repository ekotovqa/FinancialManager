using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Core
{
    public class ExpenseTypeService : BaseService<ExpenseTypeDto, ExpenseType>, IExpenseTypeService
    {
        public ExpenseTypeService(AppDbContext context, IMapper mapper) : base(context, mapper)
        {          
        }
        public async Task<List<ExpenseOperationDto>> GetExpenseTypeOperations(int id)
        {

            return _mapper.Map<List<ExpenseOperationDto>>(await _context.Set<ExpenseOperationDto>().Where(t => t.ExpenseTypeId == id).ToListAsync());
        }
    }
}

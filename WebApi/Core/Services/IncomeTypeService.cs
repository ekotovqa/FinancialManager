using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Core
{
    public class IncomeTypeService : BaseService<IncomeTypeDto, IncomeType>, IIncomeTypeService
    {
        public IncomeTypeService(AppDbContext context, IMapper mapper) : base(context, mapper)
        {        
        }
        public async Task<List<IncomeOperationDto>> GetIncomeTypeOperations(int id)
        {

            return _mapper.Map<List<IncomeOperationDto>>(await _context.Set<IncomeOperation>().Where(t => t.IncomeTypeId == id).ToListAsync());
        }
    }
}

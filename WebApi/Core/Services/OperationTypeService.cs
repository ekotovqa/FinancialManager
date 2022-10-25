using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Core
{
    public class OperationTypeService : BaseService<OperationTypeDto, OperationType>, IOperationTypeService
    {
        public OperationTypeService(AppDbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public async Task<List<OperationDto>> GetOperations(int id)
        {
            return _mapper.Map<List<OperationDto>>(await _context.Set<Operation>().Where(t => t.OperationTypeId == id).ToListAsync());
        }
    }
}

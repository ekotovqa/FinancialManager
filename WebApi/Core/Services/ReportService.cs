using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Core
{
    public class ReportService : IReportService
    {
        protected AppDbContext _context;
        protected IMapper _mapper;

        public ReportService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<DailyReport> GetDailyReport(DateTime reportDate)
        {
            IQueryable<Operation> query = _context.Set<Operation>();
            var incomeOperations = query.Where(n => n.Date.Date == reportDate.Date & n.OperationType.IsIncome);
            var expenseOperations = query.Where(n => n.Date.Date == reportDate.Date & !n.OperationType.IsIncome);
            return new DailyReport()
            {
                ReportDate = reportDate,
                TotalExpense = expenseOperations.Sum(n => n.Sum),
                TotalIncome = incomeOperations.Sum(n => n.Sum),
                IncomeOperations = _mapper.Map<List<OperationDto>>(await incomeOperations.ToListAsync()),
                ExpenseOperations = _mapper.Map<List<OperationDto>>(await expenseOperations.ToListAsync()),
            };
        }

        public async Task<PeriodReport> GetPeriodReport(DateTime startDate, DateTime endDate)
        {
            IQueryable<Operation> query = _context.Set<Operation>();
            var incomeOperations = query.Where(n => (n.Date.Date >= startDate.Date && n.Date.Date <= endDate.Date) & n.OperationType.IsIncome);
            var expenseOperations = query.Where(n => (n.Date.Date >= startDate.Date && n.Date.Date <= endDate.Date) & !n.OperationType.IsIncome);
            return new PeriodReport()
            {
                StartDate = startDate,
                EndDate = endDate,
                TotalExpense = expenseOperations.Sum(n => n.Sum),
                TotalIncome = incomeOperations.Sum(n => n.Sum),
                IncomeOperations = _mapper.Map<List<OperationDto>>(await incomeOperations.ToListAsync()),
                ExpenseOperations = _mapper.Map<List<OperationDto>>(await expenseOperations.ToListAsync()),
            };
        }
    }
}

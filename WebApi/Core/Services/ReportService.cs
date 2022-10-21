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
            var incomeOperations = _mapper.Map<List<IncomeOperationDto>>(await _context.Set<IncomeOperation>().Where(n => n.Date == reportDate).ToListAsync());
            var expenseOperations = _mapper.Map<List<ExpenseOperationDto>>(await _context.Set<ExpenseOperation>().Where(n => n.Date == reportDate).ToListAsync());
            return new DailyReport()
            {
                ReportDate = reportDate,
                IncomeOperations = incomeOperations,
                ExpenseOperations = expenseOperations,
                TotalExpense = expenseOperations.Sum(n => n.Sum),
                TotalIncome = incomeOperations.Sum(n => n.Sum)
            };
        }

        public async Task<PeriodReport> GetPeriodReport(DateTime startDate, DateTime endDate)
        {
            var incomeOperations = _mapper.Map<List<IncomeOperationDto>>(await _context.Set<IncomeOperation>().Where(n => (n.Date >= startDate && n.Date <= endDate)).ToListAsync());
            var expenseOperations = _mapper.Map<List<ExpenseOperationDto>>(await _context.Set<ExpenseOperation>().Where(n => (n.Date >= startDate && n.Date <= endDate)).ToListAsync());
            return new PeriodReport()
            {
                StartDate = startDate,
                EndDate = endDate,
                IncomeOperations = incomeOperations,
                ExpenseOperations = expenseOperations,
                TotalExpense = expenseOperations.Sum(n => n.Sum),
                TotalIncome = incomeOperations.Sum(n => n.Sum)
            };
        }
    }
}

namespace FinancialManagementApp
{
    public interface IReportService
    {
        Task<DailyReport> GetDailyReport(DailyReport dailyReport);
        Task<PeriodReport> GetPeriodReport(PeriodReport periodReport);
    }
}

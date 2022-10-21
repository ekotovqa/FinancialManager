namespace Core
{ 
    public interface IReportService
    {
        Task<DailyReport> GetDailyReport(DateTime reportDate);
        Task<PeriodReport> GetPeriodReport(DateTime startDate, DateTime endDate);
    }
}

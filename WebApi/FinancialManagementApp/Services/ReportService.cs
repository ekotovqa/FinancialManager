namespace FinancialManagementApp
{
    public class ReportService : IReportService
    {
        protected readonly HttpClient _httpClient;
        public ReportService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public Task<DailyReport> GetDailyReport(DailyReport dailyReport)
        {
            return _httpClient.GetFromJsonAsync<DailyReport>($"Reports/DailyReport?reportDate={dailyReport.ReportDate.ToString("yyyy.MM.dd")}");
        }

        public Task<PeriodReport> GetPeriodReport(PeriodReport periodReport)
        {
            return _httpClient.GetFromJsonAsync<PeriodReport>($"Reports/PeriodReport?startDate={periodReport.StartDate.ToString("yyyy.MM.dd")}&endDate={periodReport.EndDate.ToString("yyyy.MM.dd")}");
        }
    }
}

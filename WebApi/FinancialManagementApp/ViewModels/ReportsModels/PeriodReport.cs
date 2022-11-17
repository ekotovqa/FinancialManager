namespace FinancialManagementApp
{
    [EndReportDateValidation(ErrorMessage= "The end date cannot be less than the start date")]
    public class PeriodReport : BaseReport
    {
        public DateTime StartDate { get; set; }
           
        public DateTime EndDate { get; set; }
    }
}

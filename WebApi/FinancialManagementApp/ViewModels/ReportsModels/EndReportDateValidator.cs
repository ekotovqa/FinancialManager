using System.ComponentModel.DataAnnotations;

namespace FinancialManagementApp
{
    public class EndReportDateValidationAttribute : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            PeriodReport periodReport = value as PeriodReport;
            if (periodReport.EndDate < periodReport.StartDate)
                return false;
            return true;
        }
    }
}

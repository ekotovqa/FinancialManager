namespace FinancialManagementApp
{
    public class BaseReport
    {
        public decimal TotalIncome { get; set; }
        public decimal TotalExpense { get; set;}
        public List<OperationViewModel> IncomeOperations { get; set; }
        public List<OperationViewModel> ExpenseOperations { get; set; }
    }
}

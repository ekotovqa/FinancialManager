namespace Core
{
    public class BaseReport
    {
        public decimal TotalIncome { get; set; }
        public decimal TotalExpense { get; set;}
        public List<IncomeOperationDto> IncomeOperations { get; set; }
        public List<ExpenseOperationDto> ExpenseOperations { get; set; }
    }
}

namespace Core
{
    public class BaseReport
    {
        public decimal TotalIncome { get; set; }
        public decimal TotalExpense { get; set;}
        public List<OperationDto> IncomeOperations { get; set; }
        public List<OperationDto> ExpenseOperations { get; set; }
    }
}

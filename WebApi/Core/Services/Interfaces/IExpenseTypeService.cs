namespace Core
{
    public interface IExpenseTypeService : IEntityBaseService<ExpenseTypeDto>
    {
        Task<List<ExpenseOperationDto>> GetExpenseTypeOperations(int id);
    }
}

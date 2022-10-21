namespace Core
{
    public interface IIncomeTypeService : IEntityBaseService<IncomeTypeDto>
    {
        Task<List<IncomeOperationDto>> GetIncomeTypeOperations(int id);
    }
}

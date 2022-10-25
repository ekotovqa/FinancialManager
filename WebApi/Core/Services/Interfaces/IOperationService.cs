namespace Core
{
    public interface IOperationService : IEntityBaseService<OperationDto>
    {
        Task<List<OperationDto>> GetOperationsByType(bool isIncome);
    }
}

namespace Core
{
    public interface IOperationTypeService : IEntityBaseService<OperationTypeDto>
    {
        Task<List<OperationDto>> GetOperations(int id);
    }
}
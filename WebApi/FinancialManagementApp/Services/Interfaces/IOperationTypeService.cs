namespace FinancialManagementApp
{
    public interface IOperationTypeService : IBaseService<OperationTypeViewModel>
    {
        Task<IEnumerable<OperationViewModel>> GetOperations(string endPoint);
    }
}

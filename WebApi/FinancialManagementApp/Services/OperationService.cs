namespace FinancialManagementApp
{
    public class OperationService : BaseService<OperationViewModel>, IOperationService
    {
        public OperationService(HttpClient httpClient) : base(httpClient)
        {
        }
    }
}

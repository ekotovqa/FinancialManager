namespace FinancialManagementApp
{
    public class OperationTypeService : BaseService<OperationTypeViewModel>, IOperationTypeService
    {
        public OperationTypeService(HttpClient httpClient) : base(httpClient)
        {

        }

        public async Task<IEnumerable<OperationViewModel>> GetOperations(string endPoint)
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<OperationViewModel>>(endPoint);
        }
    }
}

namespace FinancialManagementApp
{
    public class BaseService<T> : IBaseService<T> where T : class, IEntityBase
    {
        protected readonly HttpClient _httpClient;
        public BaseService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<IEnumerable<T>> GetAsync(string endPoint)
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<T>>(endPoint);
        }

        public async Task PostAsync(string endPoint, T entity)
        {
            await _httpClient.PostAsJsonAsync(endPoint, entity);
        }

        public async Task DeleteAsync(string endPoint, T entity)
        {
            await _httpClient.DeleteAsync($"{endPoint}/{entity.Id}");
        }

        public async Task PutAsync(string endPoint, T entity)
        {
            await _httpClient.PutAsJsonAsync($"{endPoint}/{entity.Id}", entity);
        }

    }
}

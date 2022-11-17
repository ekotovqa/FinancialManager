namespace FinancialManagementApp
{
    public interface IBaseService<T> where T : class
    {
        Task<IEnumerable<T>> GetAsync(string endPoint);
        Task PostAsync(string endPoint, T entity);
        Task PutAsync(string endPoint, T entity);
        Task DeleteAsync(string endPoint, T entity);
    }
}

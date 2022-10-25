namespace Core
{
    public interface IEntityBaseService<TDto> where TDto : class
    {
        Task<IEnumerable<TDto>> GetAllAsync();
        Task<TDto> GetByIdAsync(int id);
        Task<TDto> CreateAsync(TDto entity);
        Task<bool> UpdateAsync(int id, TDto entity);
        Task<bool> DeleteAsync(int id);
    }
}

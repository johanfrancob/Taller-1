using Management.Shared.Responses;

namespace Management.Backend.UnitsOfWork.Interfaces
{
    public interface IGenericUnitOfWork<T> where T : class
    {
        Task<ActionResponse<T>> GetAsync(int id);
        Task<ActionResponse<IEnumerable<T>>> GetAsync();
        Task<ActionResponse<T>> AddAsync(T entity);
        Task<ActionResponse<T>> UpdateAsync(T model);
        Task<ActionResponse<T>> DeleteAsync(int id);
        Task<ActionResponse<IEnumerable<T>>> SearchAsync(string text);

    }
}

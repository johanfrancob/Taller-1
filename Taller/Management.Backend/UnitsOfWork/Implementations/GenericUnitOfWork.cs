using Management.Backend.Repositories.Interfaces;
using Management.Backend.UnitsOfWork.Interfaces;
using Management.Shared.Responses;

namespace Management.Backend.UnitsOfWork.Implementations
{
    public class GenericUnitOfWork<T> : IGenericUnitOfWork<T> where T : class
    {
        private readonly IGenericRepository<T> _repository;

        public GenericUnitOfWork(IGenericRepository<T> repository)
        {
            _repository = repository;
        }

        public virtual async Task<ActionResponse<T>> AddAsync(T entity) => await _repository.AddAsync(entity);

        public virtual async Task<ActionResponse<T>> DeleteAsync(int id) => await _repository.DeleteAsync(id);
        public async Task<ActionResponse<IEnumerable<T>>> SearchAsync(string text)=> await _repository.SearchAsync(text);



        public virtual async Task<ActionResponse<T>> GetAsync(int id) => await _repository.GetAsync(id);

        public async Task<ActionResponse<IEnumerable<T>>> GetAsync() => await _repository.GetAsync();


        public async Task<ActionResponse<T>> UpdateAsync(T entity) => await _repository.UpdateAsync(entity);

    }
}

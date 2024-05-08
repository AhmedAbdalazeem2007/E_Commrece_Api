

namespace Api_Core.Repositories
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        public Task<IEnumerable<T>> GetAllAsync();
        public Task<T> GetByIdAsync(int id);
        public Task Add(T item);
        public int Update(T item);
        public Task Delete(T item);
        Task<IQueryable<T>> SearchByname(string name);

       Task<IReadOnlyList<T>> GetAllWithApecAsync(ISpecification<T> specification);
        Task<T> GetbyIdSpecAsync(ISpecification<T> specification);
        Task<int> GetCountAsyncWithSpec(ISpecification<T> specification);
    }
}

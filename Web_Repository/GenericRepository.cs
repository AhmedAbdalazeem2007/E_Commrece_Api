




namespace Web_Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly FirstDataBase firstDataBase;

        public GenericRepository(FirstDataBase firstDataBase)
        {
            this.firstDataBase = firstDataBase;
        }
        public async Task Add(T item)
        {
          await  firstDataBase.Set<T>().AddAsync(item);
             firstDataBase.SaveChanges();
        }

        public async Task Delete(T item)
        {
            firstDataBase.Set<T>().Remove(item);
            firstDataBase.SaveChanges();
        }
        public Task<IQueryable<T>> SearchByname(string name)
        {
            throw new NotImplementedException();
/*            return firstDataBase.Set<T>().Where(p=>p.n*/
        }

        public int Update(T item)
        {
            firstDataBase.Set<T>().Update(item);
           return   firstDataBase.SaveChanges();
        }
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await firstDataBase.Set<T>().ToListAsync();
        }
        public async Task<T> GetByIdAsync(int id)
        {
            return await firstDataBase.Set<T>().FindAsync(id);
        }
        public async Task<IReadOnlyList<T>> GetAllWithApecAsync(ISpecification<T> specification)
        {
            return await ApplySpecification(specification).ToListAsync();
        }
        public async Task<T> GetbyIdSpecAsync(ISpecification<T> specification)
        {
            return await ApplySpecification(specification).FirstOrDefaultAsync();
        }
        public async Task<int> GetCountAsyncWithSpec(ISpecification<T> specification)
        {
            return await ApplySpecification(specification).CountAsync();
        }
        private IQueryable<T> ApplySpecification(ISpecification<T> specification)
        {
            return SpecificationEvalutor<T>.GetQuery(firstDataBase.Set<T>(), specification);
        }

        
    }
}

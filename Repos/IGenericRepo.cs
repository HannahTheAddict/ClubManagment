namespace HannahElSayed0523003.Repos
{
    public interface IGenericRepo<T> where T : class
    {
        public Task<IEnumerable<T>> GetAllAsync();
        public Task<T?> GetByIDAsync(int id);
        public Task AddAsync(T entity);
        public void Update(T entity);
        public Task Delete(int id);
        public Task SaveChangesAsync();
    }
}

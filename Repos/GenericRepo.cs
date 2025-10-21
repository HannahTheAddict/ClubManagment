using HannahElSayed0523003.DatabaseConnection;
using Microsoft.EntityFrameworkCore;

namespace HannahElSayed0523003.Repos
{
    public class GenericRepo<T> : IGenericRepo<T> where T : class
    {
        protected readonly AppDbContext db;

        public GenericRepo(AppDbContext db)
        {
            this.db = db;
        }

        public async Task AddAsync(T entity)
        {
            await db.Set<T>().AddAsync(entity);
        }

        public async Task Delete(int id)
        {
            var e = await db.Set<T>().FindAsync(id);
             db.Remove(e);
            await db.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await db.Set<T>().ToListAsync();
        }

        public async Task<T?> GetByIDAsync(int id)
        {
            return await db.Set<T>().FindAsync(id);
        }

        public async Task SaveChangesAsync()
        {
            await db.SaveChangesAsync();
        }

        public async void Update(T entity)
        {
            db.Update(entity);
            await db.SaveChangesAsync();
        }
    }
}

using Microsoft.EntityFrameworkCore;
using SmartParkInnovate.Data;

namespace SmartParkInnovate.Infrastructure.Repository
{
    public class Repository : IRepository
    {
        private readonly DbContext context;

        public Repository(ApplicationDbContext context)
        {
            this.context = context;
        }

        
        public IQueryable<T> All<T>() where T : class
        {
            return this.DbSet<T>();
        }

        public IQueryable<T> AllAsReadOnly<T>() where T : class
        {
            return this.DbSet<T>().AsNoTracking();
        }

        public async Task AddAsync<T>(T entity) where T : class
        {
            await DbSet<T>().
        }

        public async Task<T?> GetByIdAsync<T>(object id) where T : class
        {
            throw new NotImplementedException();
        }

        public Task<int> SaveChangesAsync()
        {
            throw new NotImplementedException();
        }

        private IQueryable<T> DbSet<T>() where T : class
        {
            return this.context.Set<T>();
        }
    }
}

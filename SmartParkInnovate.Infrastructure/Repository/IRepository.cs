namespace SmartParkInnovate.Infrastructure.Repository
{
    public interface IRepository
    {
        public IQueryable<T> All<T>() where T : class;

        public IQueryable<T> AllAsReadOnly<T>() where T : class;

        Task AddAsync<T>(T entity) where T : class;

        Task<int> SaveChangesAsync();

        Task<T?> GetByIdAsync<T>(object id) where T : class;
    }
}

namespace SmartParkInnovate.Infrastructure.Repository
{
    public interface IRepository
    {
        public IQueryable<T> All<T>();

        public IQueryable<T> AllAsReadOnly<T>();
    }
}

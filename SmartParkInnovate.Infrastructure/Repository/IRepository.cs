namespace SmartParkInnovate.Infrastructure.Repository
{
    public interface IRepository
    {
        public IQueryable<T> All<T>() where T : class;

        public IQueryable<T> AllAsReadOnly<T>() where T : class;
    }
}

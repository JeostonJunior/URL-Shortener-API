namespace LinkShortener.Repository
{
    public interface IRepository<T>
    {
        T GetById(string url);
        void Add(T entity);
    }
}

namespace LinkShortener.Repository
{
    public interface IRepository<T>
    {
        T GetShortUrl(string url);
        T GetFullUrl(string url);
        void Add(T entity);
    }
}

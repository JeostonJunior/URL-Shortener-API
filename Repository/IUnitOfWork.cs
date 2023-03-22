namespace LinkShortener.Repository
{
    public interface IUnitOfWork
    {
        Repository UrlRepository { get; }
        void Commit();
    }
}

namespace LinkShortener.Models.Interfaces
{
    public interface ILinkModel
    {
        public string FullUrl { get; set; }
        public string ShortUrl { get; set; }
    }
}

using LinkShortener.Model;

namespace LinkShortener.Services.Interfaces
{
    public interface IAssignLinkService
    {
        public string AssignLink(string fullUrl);
        public string GetAssignLink(string shortUrl);
    }
}

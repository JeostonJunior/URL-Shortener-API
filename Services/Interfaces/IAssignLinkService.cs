using LinkShortener.Models;

namespace LinkShortener.Services.Interfaces
{
    public interface IAssignLinkService
    {
        public string AssignShortId(string fullUrl);
        public string GetAssignLink(string shortUrl);
    }
}

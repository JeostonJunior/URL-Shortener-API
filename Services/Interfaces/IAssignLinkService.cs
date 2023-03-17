using LinkShortener.Models;

namespace LinkShortener.Services.Interfaces
{
    public interface IAssignLinkService
    {
        public string AssignShortId(TinyUrlRequest tinyUrl);
    }
}

using LinkShortener.Models.Interfaces;
using LinkShortener.Services.Interfaces;
using shortid;
using shortid.Configuration;
using System.Web;

namespace LinkShortener.Services
{
    public class AssignLinkService : IAssignLinkService
    {
        private const int LENGTH = 8;

        private Dictionary<string, string> _ShortIdStore;

        private ILinkModel _linkModel;

        public AssignLinkService(ILinkModel linkModel)
        {
            _ShortIdStore = new Dictionary<string, string>();
            _linkModel = linkModel;
        }

        public string AssignLink(string fullUrl)
        {
            try
            {
                var shortIdOptions = new GenerationOptions(useNumbers: true, useSpecialCharacters: false, length: LENGTH);

                var shortUrl = ShortId.Generate(shortIdOptions);

                _linkModel.FullUrl = HttpUtility.UrlDecode(fullUrl);

                _linkModel.ShortUrl = shortUrl;

                _ShortIdStore.Add(_linkModel.ShortUrl, _linkModel.FullUrl);

                return _linkModel.ShortUrl;
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }

        public string GetAssignLink(string shortUrl)
        {
            var decodedShortUlr = shortUrl.ToString();
            return _ShortIdStore[decodedShortUlr];
        }
    }
}

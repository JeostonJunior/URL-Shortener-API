using LinkShortener.Models;
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

        private UrlModel _UrlModel;

        public AssignLinkService(UrlModel urlModel)
        {
            _ShortIdStore = new Dictionary<string, string>();
            _UrlModel = urlModel;
        }

        public string AssignShortId(string fullUrl)
        {
            try
            {
                var shortIdOptions = new GenerationOptions(useNumbers: true, useSpecialCharacters: false, length: LENGTH);

                var encodedIdGenerate = ShortId.Generate(shortIdOptions);

                _UrlModel.FullUrl = HttpUtility.UrlDecode(fullUrl);

                _UrlModel.ShortUrl = encodedIdGenerate;

                _ShortIdStore.Add(_UrlModel.ShortUrl, _UrlModel.FullUrl);

                return _UrlModel.ShortUrl;
            }
            catch (Exception)
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

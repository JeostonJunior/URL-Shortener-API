using LinkShortener.Models;
using LinkShortener.Services.Interfaces;
using shortid;
using shortid.Configuration;

namespace LinkShortener.Services
{
    public class AssignLinkService : IAssignLinkService
    {
        private const int LENGTH = 8;
        private const string DOMAIN = "TinyUrl/";
        private Dictionary<string, string> _ShortIdStore;
        private UrlModel _UrlModel;

        public AssignLinkService()
        {
            _ShortIdStore = new Dictionary<string, string>();
            _UrlModel = new UrlModel();
        }

        public string AssignShortId(TinyUrlRequest tinyUrl)
        {

            var fullUrl = "";

            try
            {
                fullUrl = tinyUrl.FullUrl;
            }
            catch (Exception)
            {

                throw new Exception();
            }

            var shortedUrl = GenerateShortUrl(tinyUrl.Prefix);

            return shortedUrl;
        }

        private string GenerateShortUrl(string prefix)
        {
            try
            {
                var generateShortIdOptions = new GenerationOptions(useNumbers: true, useSpecialCharacters: false, length: LENGTH);

                var generateEncodedId = ShortId.Generate(generateShortIdOptions);

                return $"{DOMAIN}{prefix}{generateEncodedId}";
            }
            catch (Exception)
            {

                throw new Exception();
            }
        }
    }
}

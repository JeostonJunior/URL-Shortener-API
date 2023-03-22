using LinkShortener.Models;
using LinkShortener.Repository;
using LinkShortener.Services.Interfaces;
using shortid;
using shortid.Configuration;
using System.Web;

namespace LinkShortener.Services
{
    public class AssignLinkService : IAssignLinkService
    {
        private const int LENGTH = 8;
        private const string DOMAIN = "TinyUrl/";
        private const string HOST = "https://localhost:7275/";

        private UrlModel _urlModel;

        private readonly IUnitOfWork _uof;

        public AssignLinkService(IUnitOfWork appDbContext)
        {
            _uof = appDbContext;
        }

        public string AssignShortId(TinyUrlRequest tinyUrl)
        {

            Uri fullUrl = null;

            try
            {
                fullUrl = new Uri(tinyUrl.FullUrl);
            }
            catch (Exception)
            {

                throw new Exception();
            }

            var getShortLink = GetShortAssignLink(fullUrl.ToString());

            if (string.IsNullOrEmpty(getShortLink))
            {
                var generatedShortedUrl = GenerateShortUrl();
                var shortenedUrl = ContextDB(fullUrl.ToString(), generatedShortedUrl);
                return $"{HOST}{DOMAIN}{shortenedUrl}";
            }
            
            return $"{HOST}{DOMAIN}{getShortLink}";
        }

        public string GetShortAssignLink(string url)
        {
            try
            {
                url = HttpUtility.UrlDecode(url);

                var findFullUrl = _uof.UrlRepository.GetFullUrl(url);

                if (string.IsNullOrEmpty(findFullUrl.ShortUrl))
                {
                    return string.Empty;
                }

                return findFullUrl.ShortUrl;
            }
            catch (Exception)
            {

                throw new Exception();
            }
        }


        public string GetFullAssignLink(string url)
        {
            try
            {
                url = HttpUtility.UrlDecode(url);

                var findFullUrl = _uof.UrlRepository.GetShortUrl(url);

                if (string.IsNullOrEmpty(findFullUrl.FullUrl))
                {
                    return string.Empty;
                }

                return findFullUrl.FullUrl;
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        private string GenerateShortUrl()
        {
            try
            {
                var generateShortIdOptions = new GenerationOptions(useNumbers: true, useSpecialCharacters: false, length: LENGTH);

                var generateEncodedId = ShortId.Generate(generateShortIdOptions);

                return generateEncodedId;
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        private string ContextDB(string fullUrl, string shortUrl)
        {
            try
            {
                _urlModel = new UrlModel { FullUrl = fullUrl, ShortUrl = shortUrl };

                _uof.UrlRepository.Add(_urlModel);
                _uof.Commit();

                return _urlModel.ShortUrl;
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }
    }
}

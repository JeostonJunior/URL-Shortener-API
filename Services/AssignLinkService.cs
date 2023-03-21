using LinkShortener.Context;
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
        private const string DOMAIN = "TinyUrl/";
        private const string HOST = "https://localhost:7275/";

        private UrlModel _urlModel;

        private readonly AppDbContext _context;

        public AssignLinkService(AppDbContext appDbContext)
        {
            _context = appDbContext;
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

            var generatedShortedUrl = GenerateShortUrl();

            var shortenedUrl = ContextDB(fullUrl.ToString(), generatedShortedUrl);

            return $"{HOST}{DOMAIN}{shortenedUrl}";
        }

        public string GetAssignLink(string url)
        {
            try
            {
                url = HttpUtility.UrlDecode(url);

                var findFullUrl = _context.Urls.FirstOrDefault(urlFind => urlFind.ShortUrl == url);

                if(findFullUrl is null)
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

                _context.Urls.Add(_urlModel);
                _context.SaveChanges();

                return _urlModel.ShortUrl;
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }
    }
}

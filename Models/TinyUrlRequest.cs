using System.ComponentModel.DataAnnotations;

namespace LinkShortener.Models
{
    public class TinyUrlRequest
    {
        [Required(ErrorMessage = "Insira uma Url")]
        public string FullUrl { get; set; }
        public string Prefix { get; set; }

        public TinyUrlRequest(string fullUrl, string prefix)
        {
            FullUrl = fullUrl;
            Prefix = prefix;
        }
    }
}

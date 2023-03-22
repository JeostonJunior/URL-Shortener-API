using System.ComponentModel.DataAnnotations;

namespace LinkShortener.Models
{
    public class TinyUrlRequest
    {
        [Required(ErrorMessage = "Insira uma Url")]
        public string FullUrl { get; set; }
    }
}

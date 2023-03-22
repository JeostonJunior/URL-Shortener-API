using System.ComponentModel.DataAnnotations;

namespace LinkShortener.Models
{
    public class UrlModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Informe a Url", AllowEmptyStrings = false)]
        public string FullUrl { get; set; }

        [Required]
        public string ShortUrl { get; set; }
    }
}

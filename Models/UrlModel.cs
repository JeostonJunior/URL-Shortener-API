using System.ComponentModel.DataAnnotations;

namespace LinkShortener.Models
{
    public class UrlModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string FullUrl { get; set; }
        [Required]
        public string ShortUrl { get; set; }
    }
}

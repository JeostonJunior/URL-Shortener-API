using LinkShortener.Models.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace LinkShortener.Model
{
    public class LinkModel: ILinkModel
    {
        [Required]
        public string FullUrl { get; set; }

        [Required]
        public string ShortUrl { get; set; }
        
    }
}

using System.ComponentModel.DataAnnotations;

namespace Velox_Url.Dtos
{
    public record  UpdateUrlDto
    {
        [Required]
        public long UrlId { get; set; }
        [Required]
        public required string OriginalUrl { get; set; }
    }
}

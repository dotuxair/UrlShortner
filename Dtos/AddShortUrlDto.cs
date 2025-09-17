using System.ComponentModel.DataAnnotations;

namespace Velox_Url.Dtos
{
    public record class AddShortUrlDto
    {
        [Required]
        public required string OriginalUrl { get; init; }
        public bool IsCustom { get; init; } 
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Velox_Url.Data.Entities
{
    [Index(nameof(ShortUrlCode), IsUnique = true)]
    public class ShortUrl : BaseEntity
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }

        [Required]
        [Column("original_url")]
        public required string OriginalUrl { get; set; }

        [Required]
        [Column("short_url_code")]
        public required string ShortUrlCode { get; set; }
        [Column("click_count")]
        public int ClickCount { get; set; } = 0;

        [Column("is_custom")]
        public bool IsCustom { get; set; } = false;

        [Column("last_used_at")]
        public DateTimeOffset? LastUsedAt { get; set; }

        [Column("expired_at")]
        public DateTimeOffset? ExpiredAt { get; set; }


    }
}

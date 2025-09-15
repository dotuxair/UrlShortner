using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Velox_Url.Data.Entities
{
    public class UrlLog
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }

        [Column("ip_address")]
        public string? IpAddress { get; set; }

        [Column("device")]
        public string? Device { get; set; }

        [Column("browser")]
        public string? Browser { get; set; }

        [Column("operating_system")]
        public string? OperatingSystem { get; set; }

        [Column("referrer_url")]
        public string? ReferrerUrl { get; set; }

        [Column("country")]
        public string? Country { get; set; }

        [Column("city")]
        public string? City { get; set; }

        [Column("created_at")]
        public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;

        [Column("short_url_id")]
        public long ShortUrlId { get; set; }

        [ForeignKey("ShortUrlId")]
        public ShortUrl? ShortUrl { get; set; }
    }
}

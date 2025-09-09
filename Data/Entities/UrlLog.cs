using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Velox_Url.Data.Entities;

namespace VeloxUrl.Entities
{
    public class UrlLog : BaseEntity
    {
        [Key]
        public long Id { get; set; }

        public DateTimeOffset AccessedAt { get; set; } = DateTimeOffset.UtcNow;

        public string? IpAddress { get; set; }

        public string? Device { get; set; }              // e.g., "Mobile", "Desktop", "Tablet"
        public string? Browser { get; set; }             // e.g., "Chrome", "Firefox"
        public string? OperatingSystem { get; set; }     // e.g., "Windows 11", "iOS 17"
        public string? ReferrerUrl { get; set; }         // Where the user came from

        public string? Country { get; set; }             // Optional: GeoIP lookup
        public string? City { get; set; }

        [ForeignKey("ShortUrl")]
        public int ShortUrlId { get; set; }
        public ShortUrl? ShortUrl { get; set; }           // Navigation property
    }
}

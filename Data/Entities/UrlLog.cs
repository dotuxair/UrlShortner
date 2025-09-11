using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Velox_Url.Data.Entities
{
    public class UrlLog : BaseEntity
    {
        [Key]
        public long Id { get; set; }

        public DateTimeOffset AccessedAt { get; set; } = DateTimeOffset.UtcNow;

        public string? IpAddress { get; set; }

        public string? Device { get; set; }              
        public string? Browser { get; set; }             
        public string? OperatingSystem { get; set; }     
        public string? ReferrerUrl { get; set; }         

        public string? Country { get; set; }             
        public string? City { get; set; }

        [ForeignKey("ShortUrl")]
        public int ShortUrlId { get; set; }
        public ShortUrl? ShortUrl { get; set; }          
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Velox_Url.Data.Entities
{
    public class UtmLog
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }

        [Column("utm_source")]
        public string? UtmSource { get; set; }      // e.g., "facebook", "google"

        [Column("utm_medium")]
        public string? UtmMedium { get; set; }      // e.g., "cpc", "email"

        [Column("utm_campaign")]
        public string? UtmCampaign { get; set; }    // e.g., "summer_sale", "launch2025"

        [Column("url_log_id")]
        public long UrlLogId { get; set; }

        [ForeignKey(nameof(UrlLogId))]
        public UrlLog? UrlLog { get; set; }         // Navigation to the access log
    }
}

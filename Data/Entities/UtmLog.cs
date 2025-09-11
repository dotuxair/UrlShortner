using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Velox_Url.Data.Entities
{
    public class UtmLog
    {
        [Key]
        public long Id { get; set; }

        public string? UtmSource { get; set; }      // e.g., "facebook", "google"
        public string? UtmMedium { get; set; }      // e.g., "cpc", "email"
        public string? UtmCampaign { get; set; }    // e.g., "summer_sale", "launch2025"

        [ForeignKey("UrlLog")]
        public int UrlLogId { get; set; }
        public UrlLog? UrlLog { get; set; }          // Navigation to the access log
    }
}

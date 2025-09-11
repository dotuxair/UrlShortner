using System.ComponentModel.DataAnnotations;

namespace Velox_Url.Data.Entities
{
    public class ShortUrl : BaseEntity
    {
        [Key]
        public long Id { get; set; }
        public required string OriginalUrl { get; set; }
        public required string ShortUrlCode { get; set; }
        public int ClickCount { get; set; } = 0;         
        public bool IsCustom { get; set; } = false;
    }
}

using System.ComponentModel.DataAnnotations.Schema;

namespace Velox_Url.Data.Entities
{
    public abstract class BaseEntity
    {
        [Column("created_at")]
        public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;
        [Column("updated_at")]
        public DateTimeOffset? UpdatedAt { get; set; }
        [Column("is_deleted")]
        public bool IsDeleted { get; set; } = false;

        [Column("deleted_at")]
        public DateTimeOffset? DeletedAt { get; set; }
    }

}

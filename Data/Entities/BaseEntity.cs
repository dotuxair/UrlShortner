namespace Velox_Url.Data.Entities
{
    public abstract class BaseEntity
    {
        public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;
        public DateTimeOffset? UpdatedAt { get; set; }
        public bool IsRemoved { get; set; }
        public DateTimeOffset? DeletedAt { get; set; }
    }

}

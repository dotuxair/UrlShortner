using Microsoft.EntityFrameworkCore;
using Velox_Url.Data.Entities;

namespace Velox_Url.Data
{
    public class UrlDbContext(DbContextOptions<UrlDbContext> options) : DbContext(options)
    {
        public DbSet<ShortUrl> ShortUrls { get; set; }
        public DbSet<UrlLog> UrlLogs { get; set; }
        public DbSet<UtmLog> UtmLogs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ShortUrl>()
                .HasIndex(su => su.ShortUrlCode)
                .IsUnique();

            modelBuilder.Entity<UrlLog>()
                .HasOne(ul => ul.ShortUrl)
                .WithMany()
                .HasForeignKey(ul => ul.ShortUrlId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<UtmLog>()
                .HasOne(ul => ul.UrlLog)
                .WithMany()
                .HasForeignKey(ul => ul.UrlLogId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

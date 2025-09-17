using Microsoft.EntityFrameworkCore;
using Velox_Url.Data;
using Velox_Url.Data.Entities;
using Velox_Url.Services.Interfaces;
using Velox_Url.Dtos;
using Velox_Url.Mappers;

namespace Velox_Url.Services
{
    public class ShortUrlService(UrlDbContext dbContext) : IShortUrlService
    {
        private readonly UrlDbContext _dbContext = dbContext;

        public async Task<ShortUrl?> GetShortUrlByIdAsync(long urlId, CancellationToken cancellationToken)
        {
            return await _dbContext.ShortUrls
                .Where(x => x.Id == urlId)
                .FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<ShortUrl?> GetOriginalUrlByShortCodeAsync(string shortUrlCode, CancellationToken cancellationToken)
        {
            return await _dbContext.ShortUrls
                .Where(x => x.ShortUrlCode == shortUrlCode)
                .FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<ShortUrl> CreateShortUrlAsync(AddShortUrlDto shortUrlDto, CancellationToken cancellationToken)
        {
            var shortUrl = shortUrlDto.ToEntity();
            _dbContext.ShortUrls.Add(shortUrl);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return shortUrl;
        }

        public async Task<ShortUrl?> UpdateShortUrlAsync(UpdateUrlDto updateUrlDto, CancellationToken cancellationToken)
        {
            var shortUrl = await _dbContext.ShortUrls.FindAsync(updateUrlDto.UrlId, cancellationToken);
            if (shortUrl == null) return null;

            shortUrl.OriginalUrl = updateUrlDto.OriginalUrl;
            await _dbContext.SaveChangesAsync(cancellationToken);

            return shortUrl;
        }

        public async Task<bool> DeleteShortUrlAsync(long urlId, CancellationToken cancellationToken)
        {
            var shortUrl = await _dbContext.ShortUrls.FindAsync(urlId, cancellationToken);
            if (shortUrl == null) return false;

            _dbContext.ShortUrls.Remove(shortUrl);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return true;
        }

        // Increment Click Count & Last Accessed Time  ( can use triggers for these )
        public async Task<bool> TrackShortUrlUsageAsync(long urlId, CancellationToken cancellationToken)
        {
            var shortUrl = await _dbContext.ShortUrls.FindAsync(urlId, cancellationToken);
            if (shortUrl == null) return false;

            shortUrl.ClickCount++;
            shortUrl.LastUsedAt = DateTimeOffset.UtcNow;

            await _dbContext.SaveChangesAsync(cancellationToken);
            return true;
        }

    }
}

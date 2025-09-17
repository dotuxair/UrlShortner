using System.Threading;
using System.Threading.Tasks;
using Velox_Url.Data.Entities;
using Velox_Url.Dtos;

namespace Velox_Url.Services.Interfaces
{
    public interface IShortUrlService
    {
        Task<ShortUrl?> GetShortUrlByIdAsync(long urlId, CancellationToken cancellationToken);

        Task<ShortUrl?> GetOriginalUrlByShortCodeAsync(string shortCode, CancellationToken cancellationToken);

        Task<ShortUrl> CreateShortUrlAsync(AddShortUrlDto shortUrlDto, CancellationToken cancellationToken);

        Task<ShortUrl?> UpdateShortUrlAsync(UpdateUrlDto updateUrlDto, CancellationToken cancellationToken);

        Task<bool> DeleteShortUrlAsync(long url, CancellationToken cancellationToken);

        Task<bool> TrackShortUrlUsageAsync(long id, CancellationToken cancellationToken);
    }
}

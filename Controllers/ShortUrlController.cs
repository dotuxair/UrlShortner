using Microsoft.AspNetCore.Mvc;
using Velox_Url.Services.Interfaces;
using Velox_Url.Dtos;
using Velox_Url.Data.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Velox_Url.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ShortUrlController(IShortUrlService shortUrlService) : ControllerBase
    {
        private readonly IShortUrlService _shortUrlService = shortUrlService;

        [HttpGet("{id:long}")]
        public async Task<ActionResult<BaseResponse<ShortUrl>>> GetById(long id, CancellationToken cancellationToken)
        {
            var result = await _shortUrlService.GetShortUrlByIdAsync(id, cancellationToken);
            if (result == null)
                return NotFound(new BaseResponse<ShortUrl> { Success = false, Message = "URL not found" });

            return Ok(new BaseResponse<ShortUrl> { Success = true, Data = result });
        }

        [HttpGet("{shortCode}")]
        public async Task<IActionResult> GetOriginalUrlAsync(string shortCode, CancellationToken cancellationToken)
        {
            var shortUrl = await _shortUrlService.GetOriginalUrlByShortCodeAsync(shortCode, cancellationToken);

            if (shortUrl == null || (shortUrl.ExpiredAt.HasValue && shortUrl.ExpiredAt <= DateTimeOffset.UtcNow))
            {
                return NotFound(new BaseResponse<string>
                {
                    Success = false,
                    Message = "This short URL is invalid or has expired.",
                    Data = null
                });
            }
            await _shortUrlService.TrackShortUrlUsageAsync(shortUrl.Id, cancellationToken);

            // Can redirect easily using { return Redirect(shortshortUrl.OriginalUrl) }
            return Ok(new BaseResponse<string>
            {
                Success = true,
                Message = "Original URL retrieved successfully.",
                Data = shortUrl.OriginalUrl
            });
        }

        [HttpPost]
        public async Task<ActionResult<BaseResponse<ShortUrl>>> Create([FromBody] AddShortUrlDto dto, CancellationToken cancellationToken)
        {
            var created = await _shortUrlService.CreateShortUrlAsync(dto, cancellationToken);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, new BaseResponse<ShortUrl>
            {
                Success = true,
                Data = created,
                Message = "Short URL created successfully"
            });
        }

        [HttpPut]
        public async Task<ActionResult<BaseResponse<ShortUrl>>> Update([FromBody] UpdateUrlDto dto, CancellationToken cancellationToken)
        {
            var updated = await _shortUrlService.UpdateShortUrlAsync(dto, cancellationToken);
            if (updated == null)
                return NotFound(new BaseResponse<ShortUrl> { Success = false, Message = "URL not found" });

            return Ok(new BaseResponse<ShortUrl>
            {
                Success = true,
                Data = updated,
                Message = "Short URL updated successfully"
            });
        }

        [HttpDelete("{id:long}")]
        public async Task<ActionResult<BaseResponse<object>>> Delete(long id, CancellationToken cancellationToken)
        {
            var deleted = await _shortUrlService.DeleteShortUrlAsync(id, cancellationToken);
            if (!deleted)
                return NotFound(new BaseResponse<object> { Success = false, Message = "URL not found" });

            return Ok(new BaseResponse<object> { Success = true, Message = "URL deleted successfully" });
        }

    }
}

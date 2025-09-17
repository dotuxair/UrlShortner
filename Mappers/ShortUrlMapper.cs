using System;
using Velox_Url.Data.Entities;
using Velox_Url.Dtos;

namespace Velox_Url.Mappers
{
    public static class ShortUrlMapper
    {
        public static ShortUrl ToEntity(this AddShortUrlDto dto)
        {
            return new ShortUrl
            {
                OriginalUrl = dto.OriginalUrl,
                ShortUrlCode = GenerateRandomCode(8),
                IsCustom = dto.IsCustom,
                CreatedAt = DateTimeOffset.UtcNow
            };
        }



        // for Quick Code Generation
        public static string GenerateRandomCode(int length = 8)
        {
            char[] _allowedChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789".ToCharArray();

            Random _random = new();
            char[] result = new char[length];

            for (int i = 0; i < length; i++)
            {
                result[i] = _allowedChars[_random.Next(_allowedChars.Length)];
            }
            return new string(result);
        }
    }
}

using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Text.Json;
using System.Threading.Tasks;

namespace Application.Extensions
{
    public static class DistrubutedCacheExtensions
    {
        public static async Task SetRecordAsync<T>(this IDistributedCache cache,
            string recordKey,
            T data,
            TimeSpan? absoluteExpireTime = null,
            TimeSpan? unusedExpireTime = null)
        {
            var options = new DistributedCacheEntryOptions();

            options.AbsoluteExpirationRelativeToNow = absoluteExpireTime ?? TimeSpan.FromSeconds(60);
            options.SlidingExpiration = unusedExpireTime;

            var jsonData = JsonSerializer.Serialize(data);
            await cache.SetStringAsync(recordKey, jsonData, options);
        }

        public static async Task<T> GetRecordAsync<T>(this IDistributedCache cache, string recordKey)
        {
            var jsonData = await cache.GetStringAsync(recordKey);

            if (jsonData is null)
                return default(T);

            return JsonSerializer.Deserialize<T>(jsonData);
        }
    }
}

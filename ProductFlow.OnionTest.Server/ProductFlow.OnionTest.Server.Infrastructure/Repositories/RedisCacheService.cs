using Microsoft.Extensions.Caching.Distributed;
using ProductFlow.OnionTest.Server.Domain.Interfaces;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductFlow.OnionTest.Server.Infrastructure.Repositories
{
    public class RedisCacheService : ICacheService
    {
        private readonly IDistributedCache _cache;
        private readonly IConnectionMultiplexer _redis;

        public RedisCacheService(IDistributedCache cache, IConnectionMultiplexer redis)
        {
            _cache = cache;
            _redis = redis;
        }

        public async Task<string?> GetStringAsync(string key, CancellationToken token = default)
            => await _cache.GetStringAsync(key, token);

        public async Task SetStringAsync(string key, string value, TimeSpan? expiration = null, CancellationToken token = default)
        {
            var options = new DistributedCacheEntryOptions { AbsoluteExpirationRelativeToNow = expiration ?? TimeSpan.FromMinutes(30) };
            await _cache.SetStringAsync(key, value, options, token);
        }

        public async Task RemoveAsync(string key, CancellationToken token = default)
            => await _cache.RemoveAsync(key, token);

        public async Task RemoveByPatternAsync(string pattern, CancellationToken token = default)
        {
            var server = _redis.GetServer(_redis.GetEndPoints()[0]);
            var keys = server.Keys(pattern: pattern + "*").ToArray();

            foreach (var key in keys)
            {
                await _cache.RemoveAsync(key, token);
            }
        }
    }
}

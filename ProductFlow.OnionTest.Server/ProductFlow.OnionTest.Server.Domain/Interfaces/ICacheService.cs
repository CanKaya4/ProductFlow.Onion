using System;
using System.Collections.Generic;
using System.Text;

namespace ProductFlow.OnionTest.Server.Domain.Interfaces
{
    public interface ICacheService
    {
        Task<string?> GetStringAsync(string key, CancellationToken cancellationToken = default);
        Task SetStringAsync(string key, string value, TimeSpan? expiration = null, CancellationToken cancellationToken = default);
        Task RemoveAsync(string key, CancellationToken cancellationToken = default);

        Task RemoveByPatternAsync(string pattern, CancellationToken cancellationToken = default);
    }
}

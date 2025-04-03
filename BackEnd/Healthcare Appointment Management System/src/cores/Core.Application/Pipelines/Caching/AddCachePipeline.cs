using System.Globalization;
using System.Text;
using System.Text.Json;
using MediatR;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Configuration;

namespace Core.Application.Pipelines.Caching;

public class AddCachePipeline<TRequest, TResponse>(IDistributedCache cache, IConfiguration configuration)
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>, ICacheAbleRequest
{
    private readonly CacheSettings _cacheSettings =
        configuration.GetSection("RedisConfigurations").Get<CacheSettings>()
        ?? throw new InvalidOperationException("CacheSettings not found.");

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        if (_cacheSettings.ByPassCache)
            return await next();

        if (string.IsNullOrWhiteSpace(request.CacheKey))
            throw new ArgumentException("CacheKey must be provided.", nameof(request.CacheKey));

        var cachedResponse = await cache.GetAsync(request.CacheKey, cancellationToken);
        if (cachedResponse is not null)
        {
            var deserialized = JsonSerializer.Deserialize<TResponse>(Encoding.UTF8.GetString(cachedResponse));
            if (deserialized is not null)
                return deserialized;
        }

        var response = await next();
        await SetCacheAsync(request, response, cancellationToken);
        return response;
    }

    private async Task SetCacheAsync(TRequest request, TResponse response, CancellationToken cancellationToken)
    {
        var slidingExpiration =
            request.SlidingExpiration ?? TimeSpan.FromMinutes(_cacheSettings.SlidingExpiration);

        await cache.SetAsync(request.CacheKey ?? string.Empty,
            Encoding.UTF8.GetBytes(JsonSerializer.Serialize(response)), new DistributedCacheEntryOptions
            {
                SlidingExpiration = slidingExpiration
            }, cancellationToken);

        if (!string.IsNullOrWhiteSpace(request.CacheGroupKey))
            await AddCacheKeyToGroupAsync(request, slidingExpiration, cancellationToken);
    }

    private async Task AddCacheKeyToGroupAsync(TRequest request, TimeSpan expiration,
        CancellationToken cancellationToken)
    {
        if (string.IsNullOrWhiteSpace(request.CacheGroupKey))
            return;

        var cachedGroupBytes = await cache.GetAsync(request.CacheGroupKey, cancellationToken);
        HashSet<string> cacheKeysInGroup = cachedGroupBytes is not null
            ? JsonSerializer.Deserialize<HashSet<string>>(Encoding.UTF8.GetString(cachedGroupBytes)) ?? []
            : [];

        if (!string.IsNullOrWhiteSpace(request.CacheKey))
            cacheKeysInGroup.Add(request.CacheKey);

        var groupCacheOptions = new DistributedCacheEntryOptions { SlidingExpiration = expiration };

        await cache.SetAsync(request.CacheGroupKey, JsonSerializer.SerializeToUtf8Bytes(cacheKeysInGroup),
            groupCacheOptions, cancellationToken);

        await cache.SetAsync($"{request.CacheGroupKey}:SlidingExpiration",
            Encoding.UTF8.GetBytes(expiration.TotalMinutes.ToString(CultureInfo.CurrentCulture)),
            groupCacheOptions, cancellationToken);
    }
}
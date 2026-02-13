using AutoMapper;
using MediatR;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;
using ProductFlow.OnionTest.Server.Application.Features.Queries.ProductQueries;
using ProductFlow.OnionTest.Server.Application.Features.Results.ProductResults;
using ProductFlow.OnionTest.Server.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace ProductFlow.OnionTest.Server.Application.Features.Handlers.ProductsHandlers.Read
{
    public class GetProductBySlugQueryHandler : IRequestHandler<GetProductBySlugQuery, GetProductBySlugQueryResult>
    {
        private readonly IUnitOfWork _uow;
        private readonly ICacheService _cache;
        private readonly IMapper _mapper;
        private readonly ILogger<GetProductBySlugQueryHandler> _logger;

        public GetProductBySlugQueryHandler(IUnitOfWork uow, IMapper mapper, ICacheService distributedCache, ILogger<GetProductBySlugQueryHandler> logger)
        {
            _uow = uow;
            _mapper = mapper;
            _cache = distributedCache;
            _logger = logger;
        }
        public async Task<GetProductBySlugQueryResult> Handle(GetProductBySlugQuery request, CancellationToken cancellationToken)
        {
            string cacheKey = $"product_slug_{request.Slug}";

            var cachedData = await _cache.GetStringAsync(cacheKey, cancellationToken);
            if (!string.IsNullOrEmpty(cachedData))
            {
                _logger.LogInformation("Product Slug: {Slug} cache'ten getirildi.", request.Slug);
                return JsonSerializer.Deserialize<GetProductBySlugQueryResult>(cachedData);
            }

            _logger.LogInformation("Product Slug: {Slug} cache'te yok, veritabanına gidiliyor.", request.Slug);
            var value = await _uow.Products.GetByIdSlug(request.Slug, p => p.Category);

            if (value == null)
            {
                _logger.LogWarning("Slug: {Slug} olan ürün bulunamadı.", request.Slug);
                throw new Exception("Ürün bulunamadı");
            }

            var result = _mapper.Map<GetProductBySlugQueryResult>(value);

            // 3. Redis'e Kaydet
            var serializedData = JsonSerializer.Serialize(result);
            await _cache.SetStringAsync(cacheKey, serializedData, TimeSpan.FromMinutes(30), cancellationToken);

            _logger.LogInformation("Product Slug: {Slug} veritabanından çekildi ve cache'e eklendi.", request.Slug);

            return result;
        }
    }
}

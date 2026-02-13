using AutoMapper;
using MediatR;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;
using ProductFlow.OnionTest.Server.Application.Features.Queries.ProductQueries;
using ProductFlow.OnionTest.Server.Application.Features.Results.ProductResults;
using ProductFlow.OnionTest.Server.Domain.Entities;
using ProductFlow.OnionTest.Server.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Text.Json;

namespace ProductFlow.OnionTest.Server.Application.Features.Handlers.Read
{
    public class GetProductQueryHandler : IRequestHandler<GetProductQuery, List<GetProductQueryResult>>
    {
        private readonly IUnitOfWork _uow;
        private readonly ICacheService _cache;  
        private readonly IMapper _mapper;
        private readonly ILogger<GetProductQueryHandler> _logger; 

        public GetProductQueryHandler(IUnitOfWork uow, ICacheService cache, IMapper mapper, ILogger<GetProductQueryHandler> logger)
        {
            _uow = uow;
            _cache = cache;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<List<GetProductQueryResult>> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {
            string cacheKey = $"productList_{request.MinPrice}_{request.MaxPrice}_{request.CategoryId}_{request.PageSize}_{request.PageNumber}";

            var cachedData = await _cache.GetStringAsync(cacheKey, cancellationToken);
            if (!string.IsNullOrEmpty(cachedData))
            {
                _logger.LogInformation("Ürün listesi cache'ten getirildi. Key: {CacheKey}", cacheKey);
                return JsonSerializer.Deserialize<List<GetProductQueryResult>>(cachedData);
            }

            _logger.LogInformation("Ürün listesi cache'te bulunamadı, veritabanından çekiliyor...");

            Expression<Func<Product, bool>> filter = p =>
                (!request.MinPrice.HasValue || p.Price >= request.MinPrice.Value) &&
                (!request.MaxPrice.HasValue || p.Price <= request.MaxPrice.Value) &&
                (!request.CategoryId.HasValue || p.CategoryId == request.CategoryId.Value);

            var products = await _uow.Products.GetAllAsync(
                filter,
                orderBy: q => q.OrderBy(p => p.Price),
                skip: (request.PageNumber - 1) * request.PageSize,
                take: request.PageSize,
                includes: p => p.Category);

            

            var result = _mapper.Map<List<GetProductQueryResult>>(products);
           

            var serializedData = JsonSerializer.Serialize(result);

            await _cache.SetStringAsync(cacheKey, serializedData, TimeSpan.FromMinutes(30), cancellationToken);

            _logger.LogInformation("Veritabanından çekilen {Count} adet ürün cache'e eklendi.", result.Count);

            return result;
        }
    }
}

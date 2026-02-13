using AutoMapper;
using MediatR;
using Microsoft.Extensions.Caching.Distributed;
using ProductFlow.OnionTest.Server.Application.Features.Commands.ProductCommands;
using ProductFlow.OnionTest.Server.Application.Features.Queries.ProductQueries;
using ProductFlow.OnionTest.Server.Application.Features.Results.ProductResults;
using ProductFlow.OnionTest.Server.Domain.Entities;
using ProductFlow.OnionTest.Server.Domain.Helper;
using ProductFlow.OnionTest.Server.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductFlow.OnionTest.Server.Application.Features.Handlers.Write
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand>
    {
        private readonly IUnitOfWork _uow;
        private readonly ICacheService _cache; 
        private readonly IMapper _mapper;

        public CreateProductCommandHandler(IUnitOfWork uow, ICacheService cache, IMapper mapper)
        {

            _uow = uow;
            _cache = cache;
            _mapper = mapper;
        }
        public async Task Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = _mapper.Map<Product>(request);
            product.Slug = request.Name.ToSlug();
            product.CreatedDate = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            await _uow.Products.AddAsync(product);
            await _uow.SaveChangesAsync();

            await _cache.RemoveByPatternAsync("productList_", cancellationToken);
        }
    }
}

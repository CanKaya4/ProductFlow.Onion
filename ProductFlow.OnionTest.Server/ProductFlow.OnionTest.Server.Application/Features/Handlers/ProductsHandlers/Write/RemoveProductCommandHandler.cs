using MediatR;
using Microsoft.Extensions.Caching.Distributed;
using ProductFlow.OnionTest.Server.Application.Features.Commands.ProductCommands;
using ProductFlow.OnionTest.Server.Domain.Entities;
using ProductFlow.OnionTest.Server.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductFlow.OnionTest.Server.Application.Features.Handlers.ProductsHandlers.Write
{
    public class RemoveProductCommandHandler : IRequestHandler<RemoveProductCommand>
    {
        private readonly IUnitOfWork _uow;
        private readonly ICacheService _cache; 

        public RemoveProductCommandHandler(IUnitOfWork uow, ICacheService cache)
        {
            _uow = uow;
            _cache = cache;
        }

        public async Task Handle(RemoveProductCommand request, CancellationToken cancellationToken)
        {
            var value = await _uow.Products.GetByIdAsync(request.Id);
            if (value == null)
            {
                throw new Exception($"Silinecek ürün bulunamadı. ID: {request.Id}");
            }
            var slug = value.Slug;
            await _uow.Products.RemoveAsync(value);
            await _uow.SaveChangesAsync();
            await _cache.RemoveByPatternAsync("productList_", cancellationToken);
            await _cache.RemoveAsync($"product_{request.Id}", cancellationToken);
            await _cache.RemoveAsync($"product_slug_{slug}", cancellationToken);
        }
    }
}

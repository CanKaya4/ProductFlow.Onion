using AutoMapper;
using MediatR;
using Microsoft.Extensions.Caching.Distributed;
using ProductFlow.OnionTest.Server.Application.Features.Commands.ProductCommands;
using ProductFlow.OnionTest.Server.Domain.Entities;
using ProductFlow.OnionTest.Server.Domain.Helper;
using ProductFlow.OnionTest.Server.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductFlow.OnionTest.Server.Application.Features.Handlers.ProductsHandlers.Write
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly ICacheService _cache; 

        public UpdateProductCommandHandler(IUnitOfWork uow, IMapper mapper, ICacheService cache)
        {
            _uow = uow;
            _mapper = mapper;
            _cache = cache;
        }

        public async Task Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _uow.Products.GetByIdAsync(request.Id);
            if (product == null)
                throw new Exception("Güncellenecek ürün bulunamadı " + request.Id);
            var oldSlug = product.Slug;

            _mapper.Map(request, product);

            product.Slug = request.Name.ToSlug();

            await _uow.Products.UpdateAsync(product);
            await _uow.SaveChangesAsync();
 

            await _cache.RemoveByPatternAsync("productList_", cancellationToken);
            await _cache.RemoveAsync($"product_slug_{oldSlug}", cancellationToken);
            await _cache.RemoveAsync($"product_{request.Id}", cancellationToken);
        }
    }
}

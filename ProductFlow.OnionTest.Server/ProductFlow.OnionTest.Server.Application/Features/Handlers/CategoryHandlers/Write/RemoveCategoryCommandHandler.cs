using AutoMapper;
using MediatR;
using ProductFlow.OnionTest.Server.Application.Features.Commands.ProductCommands;
using ProductFlow.OnionTest.Server.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductFlow.OnionTest.Server.Application.Features.Handlers.CategoryHandlers.Write
{
    public class RemoveCategoryCommandHandler : IRequestHandler<RemoveProductCommand>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public RemoveCategoryCommandHandler(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task Handle(RemoveProductCommand request, CancellationToken cancellationToken)
        {
            var value = await _uow.Categories.GetByIdAsync(request.Id);
            if(value == null)
            {
                throw new Exception("Silinecek kategori bulunamadı. " + request.Id);
            }
            await _uow.Categories.RemoveAsync(value);
            await _uow.SaveChangesAsync();
        }
    }
}

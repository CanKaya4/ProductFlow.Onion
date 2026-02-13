using AutoMapper;
using MediatR;
using ProductFlow.OnionTest.Server.Application.Features.Commands.CategoryCommands;
using ProductFlow.OnionTest.Server.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductFlow.OnionTest.Server.Application.Features.Handlers.CategoryHandlers.Write
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public UpdateCategoryCommandHandler(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _uow.Categories.GetByIdAsync(request.Id);
            if (category == null)
                throw new Exception("Güncellenecek Ürün Bulunamadı. " + request.Id);

            category.Name = request.Name;

            await _uow.Categories.UpdateAsync(category);
            await _uow.SaveChangesAsync();
        }
    }
}

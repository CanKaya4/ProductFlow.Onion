using MediatR;
using ProductFlow.OnionTest.Server.Application.Features.Commands.CategoryCommands;
using ProductFlow.OnionTest.Server.Domain.Entities;
using ProductFlow.OnionTest.Server.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductFlow.OnionTest.Server.Application.Features.Handlers.CategoryHandlers.Write
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand>
    {
        private readonly IUnitOfWork _uow;

        public CreateCategoryCommandHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = new Category
            {
                Name = request.Name,

            };
            await _uow.Categories.AddAsync(category);
            await _uow.SaveChangesAsync();
          
        }
    }
}

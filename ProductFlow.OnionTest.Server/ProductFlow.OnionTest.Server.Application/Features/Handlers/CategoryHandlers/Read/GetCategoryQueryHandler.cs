using MediatR;
using ProductFlow.OnionTest.Server.Application.Features.Queries.CategoryQueries;
using ProductFlow.OnionTest.Server.Application.Features.Queries.ProductQueries;
using ProductFlow.OnionTest.Server.Application.Features.Results.CategoryResults;
using ProductFlow.OnionTest.Server.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductFlow.OnionTest.Server.Application.Features.Handlers.CategoryHandlers.Read
{
    public class GetCategoryQueryHandler : IRequestHandler<GetCategoryQuery, List<GetCategoryQueryResult>>
    {
        private readonly IUnitOfWork _uow;

        public GetCategoryQueryHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<List<GetCategoryQueryResult>> Handle(GetCategoryQuery request, CancellationToken cancellationToken)
        {
            var categories = await _uow.Categories.GetAllAsync();
            var result = categories.Select(c => new GetCategoryQueryResult
            {
                Id = c.Id,
                Name = c.Name,
            }).ToList();

            return result;
        }
    }
}

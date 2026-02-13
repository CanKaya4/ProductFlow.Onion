using AutoMapper;
using MediatR;
using ProductFlow.OnionTest.Server.Application.Features.Queries.CategoryQueries;
using ProductFlow.OnionTest.Server.Application.Features.Results.CategoryResults;
using ProductFlow.OnionTest.Server.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductFlow.OnionTest.Server.Application.Features.Handlers.CategoryHandlers.Read
{
    public class GetCategoryByIdQueryHandler : IRequestHandler<GetCategoryByIdQuery, GetCategoryByIdQueryResult>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public GetCategoryByIdQueryHandler(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<GetCategoryByIdQueryResult> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _uow.Categories.GetByIdAsync(request.Id);
            var result = _mapper.Map<GetCategoryByIdQueryResult>(value);

            return result;
        }
    }
}

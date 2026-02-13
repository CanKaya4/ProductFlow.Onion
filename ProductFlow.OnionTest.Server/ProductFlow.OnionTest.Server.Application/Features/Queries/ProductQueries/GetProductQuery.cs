using MediatR;
using ProductFlow.OnionTest.Server.Application.Features.Results.ProductResults;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductFlow.OnionTest.Server.Application.Features.Queries.ProductQueries
{
    public class GetProductQuery : IRequest<List<GetProductQueryResult>>
    {
        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }
        public int? PageSize { get; set; }
        public int? PageNumber { get; set; }
        public Guid? CategoryId { get; set; }
    }
}

using MediatR;
using ProductFlow.OnionTest.Server.Application.Features.Results.ProductResults;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductFlow.OnionTest.Server.Application.Features.Queries.ProductQueries
{
    public class GetProductBySlugQuery : IRequest<GetProductBySlugQueryResult>
    {
        public string Slug { get; set; }
        public GetProductBySlugQuery(string slug)
        {
            Slug = slug;
        }
    }
}

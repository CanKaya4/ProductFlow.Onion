using ProductFlow.OnionTest.Server.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductFlow.OnionTest.Server.Application.Features.Results.CategoryResults
{
    public class GetCategoryQueryResult
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}

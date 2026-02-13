using System;
using System.Collections.Generic;
using System.Text;

namespace ProductFlow.OnionTest.Server.Application.Features.Results.ProductResults
{
    public class GetProductBySlugQueryResult
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Slug { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public string ImageUrl { get; set; }
        public string CategoryName { get; set; }
        public Guid CategoryId { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}

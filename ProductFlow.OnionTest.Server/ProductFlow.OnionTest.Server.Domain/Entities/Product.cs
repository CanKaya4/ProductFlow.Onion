using System;
using System.Collections.Generic;
using System.Text;

namespace ProductFlow.OnionTest.Server.Domain.Entities
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Slug { get; set; } // SEO dostu URL için eklendi
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public string ImageUrl { get; set; }
        public Category Category { get; set; }
        public Guid CategoryId { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}

using ProductFlow.OnionTest.Server.Application.DTOs.CategoryDTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductFlow.OnionTest.Server.Application.DTOs.ProductsDTOs
{
    public class ProductListDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Price { get; set; }
        public string Stock { get; set; }
        public string ImageUrl { get; set; }
        public string CategoryName { get; set; }
        public Guid  CategoryId { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}

using ProductFlow.OnionTest.Server.Application.DTOs.ProductsDTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductFlow.OnionTest.Server.Application.DTOs.CategoryDTOs
{
    public class CategoryDto
    {
        public string Name { get; set; }
        public ICollection<ProductListDto> Products { get; set; } = new List<ProductListDto>();
    }
}

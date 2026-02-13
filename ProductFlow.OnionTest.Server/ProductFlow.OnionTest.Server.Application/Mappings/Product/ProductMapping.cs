using AutoMapper;
using ProductFlow.OnionTest.Server.Application.Features.Commands.ProductCommands;
using ProductFlow.OnionTest.Server.Application.Features.Results.ProductResults;
using ProductFlow.OnionTest.Server.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using ProductEntity = ProductFlow.OnionTest.Server.Domain.Entities.Product;

namespace ProductFlow.OnionTest.Server.Application.Mappings.Product
{
    public class ProductMapping : Profile
    {
        public ProductMapping()
        {
            CreateMap<ProductEntity, GetProductQueryResult>()
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category != null ? src.Category.Name : "kategorisiz."));

            CreateMap<ProductEntity, GetProductByIdQueryResult>()
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category != null ? src.Category.Name : "kategorisiz."));

            CreateMap<ProductEntity, GetProductBySlugQueryResult>()
               .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category != null ? src.Category.Name : "kategorisiz."));

            CreateMap<UpdateProductCommand, ProductEntity>()
    .ForMember(dest => dest.Id, opt => opt.Ignore())
    .ForMember(dest => dest.Slug, opt => opt.Ignore())
    .ForMember(dest => dest.CreatedDate, opt => opt.Ignore());

            CreateMap<CreateProductCommand, ProductEntity>();

        }
    }
}

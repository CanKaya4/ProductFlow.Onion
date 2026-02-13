using AutoMapper;
using ProductFlow.OnionTest.Server.Application.Features.Commands.CategoryCommands;
using ProductFlow.OnionTest.Server.Application.Features.Results.CategoryResults;
using ProductFlow.OnionTest.Server.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using CategoryEntity = ProductFlow.OnionTest.Server.Domain.Entities.Category;

namespace ProductFlow.OnionTest.Server.Application.Mappings.Category
{
    public class CategoryMapping : Profile
    {
        public CategoryMapping()
        {
            CreateMap<CategoryEntity, GetCategoryQueryResult>().ReverseMap();
            CreateMap<CategoryEntity, GetCategoryByIdQueryResult>().ReverseMap();
            CreateMap<UpdateCategoryCommand, CategoryEntity>().ReverseMap();
        }
    }
}

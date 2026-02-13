using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductFlow.OnionTest.Server.Application.Features.Commands.CategoryCommands
{
    public class CreateCategoryCommand : IRequest
    {
        public string Name { get; set; }
    }
}

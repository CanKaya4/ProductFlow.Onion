using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductFlow.OnionTest.Server.Application.Features.Commands.CategoryCommands
{
    public class RemoveCategoryCommand : IRequest
    {
        public Guid Id { get; set; }
        public RemoveCategoryCommand(Guid id)
        {
            Id = id;
        }
    }
}

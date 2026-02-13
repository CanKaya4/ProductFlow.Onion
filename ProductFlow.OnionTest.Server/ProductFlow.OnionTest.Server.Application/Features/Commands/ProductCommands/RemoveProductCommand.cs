using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductFlow.OnionTest.Server.Application.Features.Commands.ProductCommands
{
    public class RemoveProductCommand : IRequest
    {
        public Guid Id { get; set; }
        public RemoveProductCommand(Guid id)
        {
            Id = id;
        }
    }
}

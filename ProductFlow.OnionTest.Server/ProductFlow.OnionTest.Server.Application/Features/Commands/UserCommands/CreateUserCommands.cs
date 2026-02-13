using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductFlow.OnionTest.Server.Application.Features.Commands.UserCommands
{
    public class CreateUserCommands : IRequest<bool>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}

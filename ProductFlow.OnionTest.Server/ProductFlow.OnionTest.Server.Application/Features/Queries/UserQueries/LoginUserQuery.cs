using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductFlow.OnionTest.Server.Application.Features.Queries.UserQueries
{
    public class LoginUserQuery : IRequest<string>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}

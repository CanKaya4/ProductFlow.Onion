using MediatR;
using Microsoft.AspNetCore.Identity;
using ProductFlow.OnionTest.Server.Application.Features.Commands.UserCommands;
using ProductFlow.OnionTest.Server.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductFlow.OnionTest.Server.Application.Features.Handlers.UserHandler.Write
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommands, bool>
    {
        private readonly UserManager<AppUser> _userManager;

        public CreateUserCommandHandler(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<bool> Handle(CreateUserCommands request, CancellationToken cancellationToken)
        {
            var user = new AppUser
            {
                Id = Guid.NewGuid(),
                FirstName = request.FirstName,
                LastName = request.LastName,
                UserName = request.UserName,
                Email = request.Email
            };
            var result = await _userManager.CreateAsync(user, request.Password);

            if (!result.Succeeded)
            {
                throw new Exception(string.Join(", ", result.Errors.Select(x => x.Description)));
            }

            return true;
        }
    }
}

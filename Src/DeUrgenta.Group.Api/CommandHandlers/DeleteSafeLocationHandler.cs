﻿using System.Threading;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;
using DeUrgenta.Domain;
using DeUrgenta.Group.Api.Commands;
using DeUrgenta.Group.Api.Validators;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DeUrgenta.Group.Api.CommandHandlers
{
    public class DeleteSafeLocationHandler : IRequestHandler<DeleteSafeLocation, Result>
    {
        private readonly IValidateRequest<DeleteSafeLocation> _validator;
        private readonly DeUrgentaContext _context;

        public DeleteSafeLocationHandler(IValidateRequest<DeleteSafeLocation> validator, DeUrgentaContext context)
        {
            _validator = validator;
            _context = context;
        }

        public async Task<Result> Handle(DeleteSafeLocation request, CancellationToken cancellationToken)
        {
            var isValid = await _validator.IsValidAsync(request);

            if (!isValid)
            {
                return Result.Failure("Validation failed");
            }

            var user = await _context.Users.FirstAsync(u => u.Sub == request.UserSub, cancellationToken);

            return Result.Success();
        }
    }
}
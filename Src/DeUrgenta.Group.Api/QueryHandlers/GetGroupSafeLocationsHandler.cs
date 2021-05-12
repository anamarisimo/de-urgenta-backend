﻿using System.Collections.Immutable;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;
using DeUrgenta.Common.Validation;
using DeUrgenta.Domain;
using DeUrgenta.Group.Api.Models;
using DeUrgenta.Group.Api.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DeUrgenta.Group.Api.QueryHandlers
{
    public class GetGroupSafeLocationsHandler : IRequestHandler<GetGroupSafeLocations, Result<IImmutableList<SafeLocationResponseModel>>>
    {
        private readonly IValidateRequest<GetGroupSafeLocations> _validator;
        private readonly DeUrgentaContext _context;

        public GetGroupSafeLocationsHandler(IValidateRequest<GetGroupSafeLocations> validator, DeUrgentaContext dbContext)
        {
            _validator = validator;
            _context = dbContext;
        }

        public async Task<Result<IImmutableList<SafeLocationResponseModel>>> Handle(GetGroupSafeLocations request, CancellationToken cancellationToken)
        {
            var isValid = await _validator.IsValidAsync(request);
            if (!isValid)
            {
                return Result.Failure<IImmutableList<SafeLocationResponseModel>>("Validation failed");
            }

            var group = await _context.Groups
                .Where(g => g.Id == request.GroupId)
                .Include(g => g.GroupSafeLocations)
                .FirstOrDefaultAsync(cancellationToken);

            return group.GroupSafeLocations.Select(gsl => new SafeLocationResponseModel
            {
                Id = gsl.Id,
                Latitude = gsl.Latitude,
                Longitude = gsl.Longitude,
                Name = gsl.Name,
                GroupId = gsl.Group.Id
            }).ToImmutableList();
        }
    }
}
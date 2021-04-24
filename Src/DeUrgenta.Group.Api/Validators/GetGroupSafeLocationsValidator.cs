﻿using System;
using System.Threading.Tasks;
using DeUrgenta.Domain;
using DeUrgenta.Group.Api.Queries;
using Microsoft.EntityFrameworkCore;

namespace DeUrgenta.Group.Api.Validators
{
    public class GetGroupSafeLocationsValidator : IValidateRequest<GetGroupSafeLocations>
    {
        private readonly DeUrgentaContext _context;

        public GetGroupSafeLocationsValidator(DeUrgentaContext context)
        {
            _context = context;
        }

        public async Task<bool> IsValidAsync(GetGroupSafeLocations request)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Sub == request.UserSub);

            if (user == null)
            {
                return false;
            }

            var isPartOfTheGroup = await _context
                    .UsersToGroups
                    .AnyAsync(utg => utg.User.Id == user.Id && utg.Group.Id == request.GroupId);

            if (!isPartOfTheGroup)
            {
                return false;
            }

            return true;
        }
    }
}
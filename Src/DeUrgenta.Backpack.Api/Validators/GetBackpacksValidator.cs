﻿using System.Threading.Tasks;
using DeUrgenta.Backpack.Api.Queries;
using DeUrgenta.Common.Validation;
using DeUrgenta.Domain;
using Microsoft.EntityFrameworkCore;

namespace DeUrgenta.Backpack.Api.Validators
{
    public class GetBackpacksValidator : IValidateRequest<GetBackpacks>
    {
        private readonly DeUrgentaContext _context;

        public GetBackpacksValidator(DeUrgentaContext context)
        {
            _context = context;
        }

        public async Task<bool> IsValidAsync(GetBackpacks request)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Sub == request.UserSub);
            if (user == null)
            {
                return false;
            }

            return true;
        }
    }
}
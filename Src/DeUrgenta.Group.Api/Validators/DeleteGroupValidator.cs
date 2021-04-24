﻿using System.Threading.Tasks;
using DeUrgenta.Domain;
using DeUrgenta.Group.Api.Commands;
using Microsoft.EntityFrameworkCore;

namespace DeUrgenta.Group.Api.Validators
{
    public class DeleteGroupValidator : IValidateRequest<DeleteGroup>
    {
        private readonly DeUrgentaContext _context;

        public DeleteGroupValidator(DeUrgentaContext context)
        {
            _context = context;
        }

        public async Task<bool> IsValidAsync(DeleteGroup request)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Sub == request.UserSub);

            if (user == null)
            {
                return false;
            }

            var isGroupAdmin = await _context.Groups.AnyAsync(g => g.Admin.Id == user.Id && g.Id == request.GroupId);

            if (!isGroupAdmin)
            {
                return false;
            }

            return true;
        }
    }
}
﻿using System.Threading.Tasks;
using DeUrgenta.Backpack.Api.Commands;
using DeUrgenta.Common.Validation;
using DeUrgenta.Domain;
using Microsoft.EntityFrameworkCore;

namespace DeUrgenta.Backpack.Api.Validators
{
    public class InviteToBackpackContributorsValidator : IValidateRequest<InviteToBackpackContributors>
    {
        private readonly DeUrgentaContext _context;

        public InviteToBackpackContributorsValidator(DeUrgentaContext context)
        {
            _context = context;
        }

        public async Task<bool> IsValidAsync(InviteToBackpackContributors request)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Sub == request.UserSub);
            var invitedUser = await _context.Users.FirstOrDefaultAsync(u => u.Id == request.UserId);

            if (user == null || invitedUser == null)
            {
                return false;
            }

            if (user.Id == invitedUser.Id)
            {
                return false;
            }

            var isContributor = await _context.BackpacksToUsers.AnyAsync(btu =>
                btu.User.Id == user.Id
                && btu.Backpack.Id == request.BackpackId);

            if (!isContributor)
            {
                return false;
            }

            var isAlreadyInvited = await _context.BackpackInvites.AnyAsync(utg =>
                utg.InvitationReceiver.Id == invitedUser.Id
                && utg.Backpack.Id == request.BackpackId);

            if (isAlreadyInvited)
            {
                return false;
            }

            var backpack = await _context.Backpacks.FirstOrDefaultAsync(g => g.Id == request.BackpackId);
            if (backpack == null)
            {
                return false;
            }

            return true;
        }
    }
}
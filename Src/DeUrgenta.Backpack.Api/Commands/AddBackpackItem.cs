﻿using System;
using CSharpFunctionalExtensions;
using DeUrgenta.Backpack.Api.Models;
using MediatR;

namespace DeUrgenta.Backpack.Api.Commands
{
    public class AddBackpackItem : IRequest<Result<BackpackItemModel>>
    {
        public string UserSub { get; }
        public Guid BackpackId { get; }
        public BackpackItemRequest BackpackItem { get; }
        public AddBackpackItem(string userSub, Guid backpackId, BackpackItemRequest backpackItem)
        {
            UserSub = userSub;
            BackpackId = backpackId;
            BackpackItem = backpackItem;
        }
    }
}

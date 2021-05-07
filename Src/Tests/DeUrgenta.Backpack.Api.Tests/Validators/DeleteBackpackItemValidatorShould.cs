﻿using System;
using System.Threading.Tasks;
using DeUrgenta.Backpack.Api.Commands;
using DeUrgenta.Backpack.Api.Validators;
using DeUrgenta.Domain;
using DeUrgenta.Domain.Entities;
using DeUrgenta.Tests.Helpers;
using Shouldly;
using Xunit;

namespace DeUrgenta.Backpack.Api.Tests.Validators
{
    [Collection(TestsConstants.DbCollectionName)]
    public class DeleteBackpackItemValidatorShould
    {
        private readonly DeUrgentaContext _dbContext;

        public DeleteBackpackItemValidatorShould(DatabaseFixture fixture)
        {
            _dbContext = fixture.Context;
        }

        [Fact]
        public async Task Invalidate_request_when_item_does_not_exist()
        {
            // Arrange
            var sut = new DeleteBackpackItemValidator(_dbContext);

            // Act
            bool isValid = await sut.IsValidAsync(new DeleteBackpackItem(Guid.NewGuid()));

            // Assert
            isValid.ShouldBeFalse();
        }

        [Fact]
        public async Task Validate_request_when_item_exists()
        {
            // Arrange
            var backpackItemId = Guid.NewGuid();
            var userId = Guid.NewGuid();

            await _dbContext.Users.AddAsync(new User
            {
                Id = userId,
                FirstName = "test-user",
                LastName = "test-user"
            });

            var backpack = new Domain.Entities.Backpack 
            { 
                Id = Guid.NewGuid(), 
                Name = "test-backpack",
                AdminUserId = userId
            };

            await _dbContext.Backpacks.AddAsync(backpack);

            await _dbContext.BackpackItem.AddAsync(new BackpackItem
            {
                Id = backpackItemId,
                Name = "test-backpack-item",
                Backpack = backpack
            });
            await _dbContext.SaveChangesAsync();

            var sut = new DeleteBackpackItemValidator(_dbContext);

            // Act
            bool isValid = await sut.IsValidAsync(new DeleteBackpackItem(backpackItemId));

            // Assert
            isValid.ShouldBeTrue();
        }
    }
}
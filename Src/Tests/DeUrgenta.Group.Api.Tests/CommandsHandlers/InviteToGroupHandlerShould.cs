﻿using System;
using System.Threading;
using System.Threading.Tasks;
using DeUrgenta.Domain;
using DeUrgenta.Group.Api.CommandHandlers;
using DeUrgenta.Group.Api.Commands;
using DeUrgenta.Group.Api.Validators;
using NSubstitute;
using Shouldly;
using Xunit;

namespace DeUrgenta.Group.Api.Tests.CommandsHandlers
{
    [Collection("Database collection")]
    public class InviteToGroupHandlerShould
    {
        private readonly DeUrgentaContext _dbContext;

        public InviteToGroupHandlerShould(DatabaseFixture fixture)
        {
            _dbContext = fixture.Context;
        }

        [Fact]
        public async Task Return_failed_result_when_validation_fails()
        {
            // Arrange
            var validator = Substitute.For<IValidateRequest<InviteToGroup>>();

            validator
                .IsValidAsync(Arg.Any<InviteToGroup>())
                .Returns(Task.FromResult(false));

            var sut = new InviteToGroupHandler(validator, _dbContext);

            // Act
            var result = await sut.Handle(new InviteToGroup("a-sub", Guid.NewGuid(), Guid.NewGuid()), CancellationToken.None);

            // Assert
            result.IsFailure.ShouldBeTrue();
        }
    }
}
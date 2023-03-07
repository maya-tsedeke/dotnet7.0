﻿using Applications.Contracts.Identity;
using Applications.Models.Common;
using Domain.Entities.User;
using Mediator;
using Microsoft.Extensions.Logging;

namespace Applications.Features.Users.Commands.Create;

public class UserCreateHandler : IRequestHandler<UserCreateCommand, OperationResult<UserCreateCommandResult>>
{

    private readonly IAppUserManager _userManager;
    private readonly IMediator _mediator;
    private readonly ILogger<UserCreateHandler> _logger;
    public UserCreateHandler(IAppUserManager userRepository, IMediator mediator, ILogger<UserCreateHandler> logger)
    {
        _userManager = userRepository;
        _mediator = mediator;
        _logger = logger;
    }

    public async ValueTask<OperationResult<UserCreateCommandResult>> Handle(UserCreateCommand request, CancellationToken cancellationToken)
    {
        var userNameExist = await _userManager.IsExistUser(request.PhoneNumber);

        if (userNameExist)
            return OperationResult<UserCreateCommandResult>.FailureResult("Phone number already exists");

        var phoneNumberExist = await _userManager.IsExistUserName(request.UserName);

        if (phoneNumberExist)
            return OperationResult<UserCreateCommandResult>.FailureResult("Username already exists");

        var user = new User { UserName = request.UserName, Name = request.FirstName, FamilyName = request.LastName, PhoneNumber = request.PhoneNumber };

        var createResult = await _userManager.CreateUser(user);

        if (!createResult.Succeeded)
        {
            return OperationResult<UserCreateCommandResult>.FailureResult(string.Join(",", createResult.Errors.Select(c => c.Description)));
        }

        var code = await _userManager.GeneratePhoneNumberConfirmationToken(user, user.PhoneNumber);


        _logger.LogWarning($"Generated Code for User ID {user.Id} is {code}");

        //TODO Send Code Via Sms Provider

        return OperationResult<UserCreateCommandResult>.SuccessResult(new UserCreateCommandResult { UserGeneratedKey = user.GeneratedCode });
    }
}
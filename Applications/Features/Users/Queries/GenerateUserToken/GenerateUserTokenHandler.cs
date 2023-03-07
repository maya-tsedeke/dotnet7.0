﻿using Applications.Contracts;
using Applications.Contracts.Identity;
using Applications.Features.Users.Queries.GenerateUserToken.Model;
using Applications.Models.Common;
using Applications.Models.Jwt;
using Kernel.Extensions;
using Mediator;

namespace Applications.Features.Users.Queries.GenerateUserToken;

public class GenerateUserTokenHandler : IRequestHandler<GenerateUserTokenQuery, OperationResult<AccessToken>>
{
    private readonly IJwtService _jwtService;
    private readonly IAppUserManager _userManager;


    public GenerateUserTokenHandler(IJwtService jwtService, IAppUserManager userManager)
    {
        _jwtService = jwtService;
        _userManager = userManager;
    }

    public async ValueTask<OperationResult<AccessToken>> Handle(GenerateUserTokenQuery request, CancellationToken cancellationToken)
    {
        var user = await _userManager.GetUserByCode(request.UserKey);

        if (user is null)
            return OperationResult<AccessToken>.FailureResult("User Not found");

        var result = user.PhoneNumberConfirmed ? await _userManager.VerifyUserCode(
            user, request.Code) : await _userManager.ChangePhoneNumber(user, user.PhoneNumber, request.Code);


        if (!result.Succeeded)
            return OperationResult<AccessToken>.FailureResult(result.Errors.StringifyIdentityResultErrors());

        await _userManager.UpdateUserAsync(user);

        var token = await _jwtService.GenerateAsync(user);

        return OperationResult<AccessToken>.SuccessResult(token);
    }
}
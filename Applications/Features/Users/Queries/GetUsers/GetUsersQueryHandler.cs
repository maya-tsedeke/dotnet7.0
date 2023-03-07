﻿using Applications.Contracts.Identity;
using Applications.Features.Users.Queries.GetUsers.Model;
using Applications.Models.Common;
using AutoMapper;
using Domain.Entities.User;
using Mediator;

namespace Applications.Features.Users.Queries.GetUsers;

internal class GetUsersQueryHandler : IRequestHandler<GetUsersQueryModel, OperationResult<List<GetUsersQueryResponseModel>>>
{
    readonly IAppUserManager _userManager;
    private readonly IMapper _mapper;

    public GetUsersQueryHandler(IAppUserManager userManager, IMapper mapper)
    {
        _userManager = userManager;
        _mapper = mapper;
    }

    public async ValueTask<OperationResult<List<GetUsersQueryResponseModel>>> Handle(GetUsersQueryModel request, CancellationToken cancellationToken)
    {
        var usersModel =
            (await _userManager.GetAllUsersAsync()).Select(_mapper.Map<User, GetUsersQueryResponseModel>).ToList();

        if (!usersModel.Any())
            return OperationResult<List<GetUsersQueryResponseModel>>.NotFoundResult("No Users Found!");

        return OperationResult<List<GetUsersQueryResponseModel>>.SuccessResult(usersModel);
    }
}
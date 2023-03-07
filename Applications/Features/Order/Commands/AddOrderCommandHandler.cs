﻿using Applications.Contracts.Identity;
using Applications.Contracts.Persistence;
using Applications.Models.Common;
using Mediator;

namespace Applications.Features.Order.Commands;

internal class AddOrderCommandHandler : IRequestHandler<AddOrderCommand, OperationResult<bool>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IAppUserManager _userManager;

    public AddOrderCommandHandler(IUnitOfWork unitOfWork, IAppUserManager userManager)
    {
        _unitOfWork = unitOfWork;
        _userManager = userManager;
    }

    public async ValueTask<OperationResult<bool>> Handle(AddOrderCommand request, CancellationToken cancellationToken)
    {
        var user = await _userManager.GetUserByIdAsync(request.UserId);

        if (user == null)
            return OperationResult<bool>.FailureResult("User Not Found");

        await _unitOfWork.OrderRepository.AddOrderAsync(new Domain.Entities.Order.Order()
        { UserId = user.Id, OrderName = request.OrderName });

        await _unitOfWork.CommitAsync();

        return OperationResult<bool>.SuccessResult(true);
    }
}
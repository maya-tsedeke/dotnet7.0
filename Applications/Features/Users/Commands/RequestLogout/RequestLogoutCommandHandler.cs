
using Applications.Contracts.Identity;
using Applications.Models.Common;
using Mediator;

namespace Applications.Features.Users.Commands.RequestLogout
{
    internal class RequestLogoutCommandHandler : IRequestHandler<RequestLogoutCommandModel, OperationResult<bool>>
    {
        private readonly IAppUserManager _userManager;

        public RequestLogoutCommandHandler(IAppUserManager userManager)
        {
            _userManager = userManager;
        }

        public async ValueTask<OperationResult<bool>> Handle(RequestLogoutCommandModel request, CancellationToken cancellationToken)
        {
            var user = await _userManager.GetUserByIdAsync(request.UserId);

            if (user == null)
                return OperationResult<bool>.FailureResult("User not found");

            await _userManager.UpdateSecurityStampAsync(user);

            return OperationResult<bool>.SuccessResult(true);
        }
    }
}

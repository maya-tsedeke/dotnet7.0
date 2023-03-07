using Applications.Contracts;
using Applications.Models.Common;
using Applications.Models.Jwt;
using Mediator;

namespace Applications.Features.Users.Commands.RefreshUserTokenCommand
{
    internal class RefreshTokenCommandHandler : IRequestHandler<RefreshUserTokenCommand, OperationResult<AccessToken>>
    {
        private readonly IJwtService _jwtService;

        public RefreshTokenCommandHandler(IJwtService jwtService)
        {
            _jwtService = jwtService;
        }

        public async ValueTask<OperationResult<AccessToken>> Handle(RefreshUserTokenCommand request, CancellationToken cancellationToken)
        {
            var newToken = await _jwtService.RefreshToken(request.RefreshToken);

            if (newToken is null)
                return OperationResult<AccessToken>.FailureResult("Invalid refresh token");

            return OperationResult<AccessToken>.SuccessResult(newToken);
        }
    }
}

using Applications.Models.Common;
using Applications.Models.Jwt;
using Mediator;

namespace Applications.Features.Users.Commands.RefreshUserTokenCommand;

public record RefreshUserTokenCommand(string RefreshToken) : IRequest<OperationResult<AccessToken>>;
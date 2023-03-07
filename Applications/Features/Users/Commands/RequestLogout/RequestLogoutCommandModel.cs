using Applications.Models.Common;
using Mediator;

namespace Applications.Features.Users.Commands.RequestLogout;

public record RequestLogoutCommandModel(int UserId) : IRequest<OperationResult<bool>>;
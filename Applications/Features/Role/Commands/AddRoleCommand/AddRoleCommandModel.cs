using Applications.Models.Common;
using Mediator;

namespace Applications.Features.Role.Commands.AddRoleCommand;

public record AddRoleCommandModel(string RoleName) : IRequest<OperationResult<bool>>;
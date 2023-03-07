using Applications.Models.Common;
using Mediator;

namespace Applications.Features.Role.Commands.UpdateRoleClaimsCommand;

public record UpdateRoleClaimsCommandModel(int RoleId, List<string> RoleClaimValue) : IRequest<OperationResult<bool>>;
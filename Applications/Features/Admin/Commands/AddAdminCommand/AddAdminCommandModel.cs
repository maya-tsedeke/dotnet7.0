using Applications.Models.Common;
using Mediator;

namespace Applications.Features.Admin.Commands.AddAdminCommand;

public record AddAdminCommandModel(string UserName, string Email, string Password, int RoleId) : IRequest<OperationResult<bool>>;
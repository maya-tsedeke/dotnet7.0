using Applications.Contracts.Identity;
using Applications.Models.Common;
using Applications.Models.Identity;
using Mediator;

namespace Applications.Features.Role.Commands.AddRoleCommand
{
    internal class AddRoleCommandHandler : IRequestHandler<AddRoleCommandModel, OperationResult<bool>>
    {
        private readonly IRoleManagerService _roleManagerService;

        public AddRoleCommandHandler(IRoleManagerService roleManagerService)
        {
            _roleManagerService = roleManagerService;
        }

        public async ValueTask<OperationResult<bool>> Handle(AddRoleCommandModel request, CancellationToken cancellationToken)
        {
            var addRoleResult =
                await _roleManagerService.CreateRoleAsync(new CreateRoleDto() { RoleName = request.RoleName });

            if (addRoleResult.Succeeded)
                return OperationResult<bool>.SuccessResult(true);

            var errors = string.Join("\n", addRoleResult.Errors.Select(c => c.Description));

            return OperationResult<bool>.FailureResult(errors);
        }
    }
}

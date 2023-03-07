using Applications.Models.Common;
using Kernel.ValidationBase;
using Kernel.ValidationBase.Contracts;
using FluentValidation;
using Mediator;

namespace Applications.Features.Users.Commands.Create;

public record UserCreateCommand
    (string UserName, string FirstName, string LastName, string PhoneNumber) : IRequest<OperationResult<UserCreateCommandResult>>, IValidatableModel<UserCreateCommand>
{

    public IValidator<UserCreateCommand> ValidateApplicationModel(ApplicationBaseValidationModel<UserCreateCommand> validator)
    {
        validator
            .RuleFor(c => c.FirstName)
            .NotEmpty()
            .NotNull()
            .WithMessage("User must have first name");

        validator
            .RuleFor(c => c.LastName)
            .NotEmpty()
            .NotNull()
            .WithMessage("User must have last name");

        return validator;
    }
}